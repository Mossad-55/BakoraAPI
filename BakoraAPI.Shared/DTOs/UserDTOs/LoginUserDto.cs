﻿namespace BakoraAPI.Shared.DTOs.UserDTOs;

public record LoginUserDto
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}
