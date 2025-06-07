using BakoraAPI.Shared.DTOs.Admin;
using BakoraAPI.Shared.DTOs.Provider;
using BakoraAPI.Shared.DTOs.Requester;
using BakoraAPI.Shared.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;

namespace BakoraAPI.Services.Contracts;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterAdminAsync(AdminRegisterDto dto);
    Task<IdentityResult> RegisterProviderAsync(ProviderRegisterDto dto);
    Task<IdentityResult> RegisterRequesterAsync(RequesterRegisterDto dto);
    Task<IdentityResult> UpdateAdminAsync(AdminUpdateDto dto);
    Task<IdentityResult> UpdateProviderAsync(ProviderUpdateDto dto);
    Task<IdentityResult> UpdateRequesterAsync(RequesterUpdateDto dto);
    Task<LoginResponseDto> LoginUser(LoginUserDto dto);
    Task<TokenDto> GenerateToken(bool populateExpiry);
    Task<TokenDto> RefreshToken(TokenDto tokenDto);
    Task<bool> BlockUserAsync(Guid userId);
}
