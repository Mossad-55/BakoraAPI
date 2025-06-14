﻿using BakoraAPI.Presentation.ActionFilters;
using BakoraAPI.Services.Contracts;
using BakoraAPI.Shared.DTOs.Admin;
using BakoraAPI.Shared.DTOs.Provider;
using BakoraAPI.Shared.DTOs.Requester;
using BakoraAPI.Shared.DTOs.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BakoraAPI.Presentation.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationServiceManager _authService;
    private readonly IFileService _fileService;

    public AuthenticationController(IAuthenticationServiceManager authService, IFileService fileService)
    {
        _authService = authService;
        _fileService = fileService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserDto dto)
    {
        var result = await _authService.AuthenticationService.LoginUser(dto);

        return Ok(result);
    }

    [HttpPost("register-admin")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterAdmin([FromForm] AdminRegisterDto dto)
    {
        try
        {
            if (dto.ProfilePicture != null)
            {
                try
                {
                    dto.ProfilePictureUrl = await _fileService.SaveFileAsync(dto.ProfilePicture);
                }
                catch (Exception ex)
                {
                    return StatusCode(400, new { message = ex.Message });
                }
            }

            var result = await _authService.AuthenticationService.RegisterAdminAsync(dto);
            if (!result.Succeeded)
            {
                // If user creation fails, delete the uploaded profile picture if it exists
                if (!string.IsNullOrEmpty(dto.ProfilePictureUrl))
                {
                    _fileService.DeleteFile(dto.ProfilePictureUrl);
                }

                foreach (var error in result.Errors)
                    ModelState.TryAddModelError(error.Code, error.Description);

                return BadRequest(ModelState);
            }
        }
        catch (Exception ex)
        {
            _fileService.DeleteFile(dto.ProfilePictureUrl);

            return StatusCode(400, new { message = ex.Message });
        }

        return StatusCode(201, new { message = "Registration successful. Please login to your account." });
    }

    [HttpPost("register-provider")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterProvider([FromForm] ProviderRegisterDto dto)
    {
        if (dto.ProfilePicture != null)
        {
            try
            {
                dto.ProfilePictureUrl = await _fileService.SaveFileAsync(dto.ProfilePicture);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        var result = await _authService.AuthenticationService.RegisterProviderAsync(dto);
        if (!result.Succeeded)
        {
            // If user creation fails, delete the uploaded profile picture if it exists
            if (!string.IsNullOrEmpty(dto.ProfilePictureUrl))
            {
                _fileService.DeleteFile(dto.ProfilePictureUrl);
            }

            foreach (var error in result.Errors)
                ModelState.TryAddModelError(error.Code, error.Description);

            return BadRequest(ModelState);
        }

        return StatusCode(201, new { message = "Registration successful. Please login to your account." });
    }

    [HttpPost("register-requester")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterRequester([FromForm] RequesterRegisterDto dto)
    {
        if (dto.ProfilePicture != null)
        {
            try
            {
                dto.ProfilePictureUrl = await _fileService.SaveFileAsync(dto.ProfilePicture);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        var result = await _authService.AuthenticationService.RegisterRequesterAsync(dto);
        if (!result.Succeeded)
        {
            // If user creation fails, delete the uploaded profile picture if it exists
            if (!string.IsNullOrEmpty(dto.ProfilePictureUrl))
            {
                _fileService.DeleteFile(dto.ProfilePictureUrl);
            }

            foreach (var error in result.Errors)
                ModelState.TryAddModelError(error.Code, error.Description);

            return BadRequest(ModelState);
        }

        return StatusCode(201, new { message = "Registration successful. Please login to your account." });
    }

    [HttpPut("update-admin")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAdmin([FromForm] AdminUpdateDto dto)
    {
        dto.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // Handling Profile Picture Upload
        if(dto.ProfilePicture != null)
        {
            try
            {
                if (dto.ProfilePictureUrl != null)
                    _fileService.DeleteFile(dto.ProfilePictureUrl);

                dto.ProfilePictureUrl = await _fileService.SaveFileAsync(dto.ProfilePicture);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }
        else if(dto.ProfilePicture == null && string.IsNullOrEmpty(dto.ProfilePictureUrl))
        {
            _fileService.DeleteFile(dto.ProfilePictureUrl ?? string.Empty);
            dto.ProfilePictureUrl = string.Empty;
        }

        var result = await _authService.AuthenticationService.UpdateAdminAsync(dto);
        if (!result.Succeeded)
        {
            // If user creation fails, delete the uploaded profile picture if it exists
            if (!string.IsNullOrEmpty(dto.ProfilePictureUrl))
            {
                _fileService.DeleteFile(dto.ProfilePictureUrl);
            }

            foreach (var error in result.Errors)
                ModelState.TryAddModelError(error.Code, error.Description);

            return BadRequest(ModelState);
        }

        return NoContent();
    }

    [HttpPut("update-provider")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "Provider")]
    public async Task<IActionResult> UpdateProvider([FromForm] ProviderUpdateDto dto)
    {
        dto.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // Handling Profile Picture Upload
        if (dto.ProfilePicture != null)
        {
            try
            {
                if (dto.ProfilePictureUrl != null)
                    _fileService.DeleteFile(dto.ProfilePictureUrl);

                dto.ProfilePictureUrl = await _fileService.SaveFileAsync(dto.ProfilePicture);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }
        else if (dto.ProfilePicture == null && string.IsNullOrEmpty(dto.ProfilePictureUrl))
        {
            _fileService.DeleteFile(dto.ProfilePictureUrl ?? string.Empty);
            dto.ProfilePictureUrl = string.Empty;
        }

        var result = await _authService.AuthenticationService.UpdateProviderAsync(dto);
        if (!result.Succeeded)
        {
            // If user creation fails, delete the uploaded profile picture if it exists
            if (!string.IsNullOrEmpty(dto.ProfilePictureUrl))
            {
                _fileService.DeleteFile(dto.ProfilePictureUrl);
            }

            foreach (var error in result.Errors)
                ModelState.TryAddModelError(error.Code, error.Description);

            return BadRequest(ModelState);
        }

        return NoContent();
    }

    [HttpPut("update-requester")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize(Roles = "Requester")]
    public async Task<IActionResult> UpdateRequester([FromForm] RequesterUpdateDto dto)
    {
        dto.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // Handling Profile Picture Upload
        if (dto.ProfilePicture != null)
        {
            try
            {
                if (dto.ProfilePictureUrl != null)
                    _fileService.DeleteFile(dto.ProfilePictureUrl);

                dto.ProfilePictureUrl = await _fileService.SaveFileAsync(dto.ProfilePicture);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }
        else if (dto.ProfilePicture == null && string.IsNullOrEmpty(dto.ProfilePictureUrl))
        {
            _fileService.DeleteFile(dto.ProfilePictureUrl ?? string.Empty);
            dto.ProfilePictureUrl = string.Empty;
        }

        var result = await _authService.AuthenticationService.UpdateRequesterAsync(dto);
        if (!result.Succeeded)
        {
            // If user creation fails, delete the uploaded profile picture if it exists
            if (!string.IsNullOrEmpty(dto.ProfilePictureUrl))
            {
                _fileService.DeleteFile(dto.ProfilePictureUrl);
            }

            foreach (var error in result.Errors)
                ModelState.TryAddModelError(error.Code, error.Description);

            return BadRequest(ModelState);
        }

        return NoContent();
    }

    [HttpPost("block-user/{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> BlockUser(Guid id)
    {
        var result = await _authService.AuthenticationService.BlockUserAsync(id);

        if(!result)
            return Ok(new { message = "User has been blocked successfully." });

        return Ok(new { message = "User has been unblocked successfully." });
    }
}
