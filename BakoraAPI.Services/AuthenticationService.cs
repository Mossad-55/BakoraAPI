using BakoraAPI.Entities.ConfigurationModels;
using BakoraAPI.Entities.Entities;
using BakoraAPI.Entities.Exceptions;
using BakoraAPI.Services.Contracts;
using BakoraAPI.Services.MappingProfiles;
using BakoraAPI.Shared.DTOs.Admin;
using BakoraAPI.Shared.DTOs.Provider;
using BakoraAPI.Shared.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BakoraAPI.Services;

internal sealed class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly IServiceManager _services;
    private readonly IOptions<JwtConfiguration> _options;

    private readonly JwtConfiguration _jwtConfiguration;
    private User? _user;

    public AuthenticationService(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager,
        IServiceManager services,
        IOptions<JwtConfiguration> options)
    {
        _services = services;
        _userManager = userManager;
        _roleManager = roleManager;
        _options = options;
        _jwtConfiguration = _options.Value;
    }

    public async Task<TokenDto> GenerateToken(bool populateExpiry)
    {
        var signingCredtials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredtials, claims);

        var refreshToken = GenerateRefreshToken();

        _user.RefreshToken = refreshToken;
        if (populateExpiry)
            _user.RefreshTokenExpiryDate = DateTime.Now.AddDays(5);

        await _userManager.UpdateAsync(_user);

        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return new TokenDto(accessToken, refreshToken);
    }

    public async Task<LoginResponseDto> LoginUser(LoginUserDto dto)
    {
        _user = await _userManager.FindByEmailAsync(dto.Email ?? string.Empty) ?? throw new FailedLoginException();

        /* Implement this later !!!!
         * 
         * if (!await _userManager.IsEmailConfirmedAsync(_user))
            throw new EmailNotConfirmedException(dto.Email);*/

        /* Implement if the use got blocked or not .
         if(_user.IsBlocked)
            throw new UserBlockedException(dto.Email);
         */

        var result = await _userManager.CheckPasswordAsync(_user, dto.Password ?? string.Empty);
        if (!result)
            throw new FailedLoginException();

        var tokenDto = await GenerateToken(populateExpiry: true);
        var userRoles = await _userManager.GetRolesAsync(_user);

        var response = new LoginResponseDto
        {
            AccessToken = tokenDto.AccessToken,
            ExpiresAt = _user.RefreshTokenExpiryDate,
            RefreshToken = tokenDto.RefreshToken,
            Role = userRoles.FirstOrDefault(),
            UserId = _user.Id,
            Email = _user.Email
        };

        return response;
    }

    public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
    {
        var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);

        var user = await _userManager.FindByNameAsync(principal.Identity.Name);
        if (user is null || user.RefreshToken != tokenDto.RefreshToken ||
            user.RefreshTokenExpiryDate <= DateTime.Now)
            throw new RefreshTokenException();

        _user = user;

        return await GenerateToken(populateExpiry: false);
    }

    public async Task<IdentityResult> RegisterAdminAsync(AdminRegisterDto dto)
    {
        // Check if email already exists
        var existingUser = await _userManager.FindByEmailAsync(dto.Email);
        if (existingUser != null)
            throw new EmailExistsException(dto.Email);

        if (!await _roleManager.RoleExistsAsync(dto.Role))
            throw new UserRoleNotFoundException(dto.Role);

        var userModel = dto.ToUserEntity();

        var result = await _userManager.CreateAsync(userModel, dto.Password);
        if (!result.Succeeded)
            return result;

        await _userManager.AddToRoleAsync(userModel, dto.Role);

        _services.AdminService.CreateAsync(userModel.Id, false);

        return result;
    }


    public async Task<IdentityResult> RegisterProviderAsync(ProviderRegisterDto dto)
    {
        var existingUser = await _userManager.FindByEmailAsync(dto.Email);
        if (existingUser != null)
            throw new EmailExistsException(dto.Email);

        if (!await _roleManager.RoleExistsAsync(dto.Role))
            throw new UserRoleNotFoundException(dto.Role);

        var userModel = dto.ToUserEntity();

        var result = await _userManager.CreateAsync(userModel, dto.Password);
        if (!result.Succeeded)
            return result;

        await _userManager.AddToRoleAsync(userModel, dto.Role);

        _services.ProviderService.CreateProviderAsync(userModel.Id, dto, false);

        return result;
    }


    public async Task<IdentityResult> UpdateAdminAsync(AdminUpdateDto dto)
    {
        var userEntity = await _userManager.FindByIdAsync(dto.UserId) ?? throw new UserNotFoundException(Guid.Parse(dto.UserId));

        // Maping
        userEntity.UpdateEntity(dto);

        var result = await _userManager.UpdateAsync(userEntity);

        return result;
    }

    public async Task<IdentityResult> UpdateProviderAsync(ProviderUpdateDto dto)
    {
        var userEntity = await _userManager.FindByIdAsync(dto.UserId) ?? throw new UserNotFoundException(Guid.Parse(dto.UserId));

        userEntity.UpdateEntity(dto);

        await _services.ProviderService.UpdateProviderAsync(Guid.Parse(dto.UserId), dto, true);

        var result = await _userManager.UpdateAsync(userEntity);

        return result;
    }

    // Private Functions
    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, _user.UserName),
            new Claim(ClaimTypes.Email, _user.Email)
        };

        var roles = await _userManager.GetRolesAsync(_user);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken
        (
            issuer: _jwtConfiguration.ValidIssuer,
            audience: _jwtConfiguration.ValidAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
            signingCredentials: signingCredentials
        );

        return tokenOptions;
    }

    private SigningCredentials GetSigningCredentials()
    {
        if (string.IsNullOrEmpty(_jwtConfiguration.SecretKey))
            throw new InvalidOperationException("JWT Secret Key is not configured");

        try
        {
            var key = Encoding.UTF8.GetBytes(_jwtConfiguration.SecretKey);

            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to create signing credentials", ex);
        }
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtConfiguration.SecretKey)),
            ValidateLifetime = true, // We want to validate an expired token
            ValidIssuer = _jwtConfiguration.ValidIssuer,
            ValidAudience = _jwtConfiguration.ValidAudience
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;

        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null)
            throw new SecurityTokenException("Invalid token format");

        if (!jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token algorithm. Expected HMAC-SHA256");

        return principal;
    }
}
