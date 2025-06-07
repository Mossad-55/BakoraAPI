namespace BakoraAPI.Shared.DTOs.Admin;

public record AdminDto
{
    public Guid? UserId { get; set; }
    public string? FullNameEn { get; set; }
    public string? FullNameAr { get; set; }
    public string? Email { get; set; } 
    public string? PhoneNumber { get; set; }
    public string? AddressEn { get; set; }
    public string? AddressAr { get; set; }
    public string? ProfilePictureUrl { get; set; }
}
