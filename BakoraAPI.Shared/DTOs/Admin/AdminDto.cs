namespace BakoraAPI.Shared.DTOs.Admin;

public record AdminDto
{
    public Guid? UserId { get; set; }
    public string? FullNameEnglish { get; set; }
    public string? FullNameArabic { get; set; }
    public string? Email { get; set; } 
    public string? PhoneNumber { get; set; }
    public string? AddressEnglish { get; set; }
    public string? AddressArabic { get; set; }
    public string? ProfilePictureUrl { get; set; }
}
