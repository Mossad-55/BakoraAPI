using Microsoft.AspNetCore.Http;

namespace BakoraAPI.Shared.DTOs.Admin;

public record AdminUpdateDto
{
    public string? UserId { get; set; }
    public string? FullNameEn { get; set; }
    public string? FullNameAr { get; set; }
    public string? PhoneNumber { get; set; }
    public string? AddressEn { get; set; }
    public string? AddressAr { get; set; }

    public IFormFile? ProfilePicture { get; set; }
    public string? ProfilePictureUrl { get; set; }
}
