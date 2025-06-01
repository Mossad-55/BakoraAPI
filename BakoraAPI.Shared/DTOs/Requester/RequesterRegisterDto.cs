using BakoraAPI.Shared.DTOs.UserDTOs;

namespace BakoraAPI.Shared.DTOs.Requester;

public record RequesterRegisterDto : UserRegisterationBaseDto
{
    public string? InstitutionNameEn { get; set; }
    public string? InstitutionNameAr { get; set; }
    public string? InstitutionTypeEn { get; set; }
    public string? InstitutionTypeAr { get; set; }
    public string? CommercialRegistrationNumber { get; set; }
    public DateTime? CommercialRegistrationDate { get; set; }
}
