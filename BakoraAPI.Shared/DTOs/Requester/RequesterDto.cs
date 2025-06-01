namespace BakoraAPI.Shared.DTOs.Requester;

public record RequesterDto
{
    public Guid? UserId { get; set; }
    public string? FullNameEn { get; set; }
    public string? FullNameAr { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? AddressEn { get; set; }
    public string? AddressAr { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? InstitutionNameEn { get; set; }
    public string? InstitutionNameAr { get; set; }
    public string? InstitutionTypeEn { get; set; }
    public string? InstitutionTypeAr { get; set; }
    public string? CommercialRegistrationNumber { get; set; }
    public string? CommercialRegistrationDate { get; set; }
}
