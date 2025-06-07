using Microsoft.AspNetCore.Http;

namespace BakoraAPI.Shared.DTOs.UserDTOs;

public record UserRegisterationBaseDto
{
    public string? FullNameEn { get; set; }
    public string? FullNameAr { get; set; }

    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public string? AddressEn { get; set; }
    public string? AddressAr { get; set; }
    public DateTime? JoiningDate { get; set; } = DateTime.UtcNow;
    public IFormFile? ProfilePicture { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? Role { get; set; }
}
