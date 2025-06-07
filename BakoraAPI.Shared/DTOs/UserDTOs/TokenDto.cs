namespace BakoraAPI.Shared.DTOs.UserDTOs;

public record TokenDto
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}
