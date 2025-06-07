using BakoraAPI.Presentation.ActionFilters;
using BakoraAPI.Services.Contracts;
using BakoraAPI.Shared.DTOs.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BakoraAPI.Presentation.Controllers;

[Route("api/token")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IAuthenticationServiceManager _service;

    public TokenController(IAuthenticationServiceManager service) => _service = service;

    [HttpPost("refresh")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "Admin, Requester, Provider")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenDto dto)
    {
        var authHeader = Request.Headers["Authorization"].ToString();

        if (!string.IsNullOrWhiteSpace(authHeader) && authHeader.StartsWith("Bearer "))
        {
            dto.AccessToken = authHeader["Bearer ".Length..].Trim(); // Extract the token

            var tokenDto = await _service.AuthenticationService.RefreshToken(dto);

            return Ok(tokenDto);
        }

        return BadRequest(new { StatusCode = 400, Message = "No token found in Authorization header" });
    }
}
