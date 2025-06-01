using Microsoft.AspNetCore.Http;

namespace BakoraAPI.Shared.DTOs.Provider;

public record ProviderUpdateDto
{
    public string? UserId { get; set; }
    public string? FullNameEn { get; set; }
    public string? FullNameAr { get; set; }
    public string? PhoneNumber { get; set; }
    public string? AddressEn { get; set; }
    public string? AddressAr { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? InstitutionNameEn { get; set; }
    public string? InstitutionNameAr { get; set; }
    public string? InstitutionTypeEn { get; set; }
    public string? InstitutionTypeAr { get; set; }
    public string? CommercialRegistrationNumber { get; set; }
    public DateTime? CommercialRegistrationDate { get; set; }
    public IFormFile? ProfilePicture {  get; set; }
}
