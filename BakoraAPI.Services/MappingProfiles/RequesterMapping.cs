using BakoraAPI.Entities.Entities;
using BakoraAPI.Shared.DTOs.Requester;

namespace BakoraAPI.Services.MappingProfiles;

public static class RequesterMapping
{
    public static Requester? ToEntity(this RequesterRegisterDto? user)
    {
        if (user == null) return null;

        return new Requester
        {
            InstitutionNameAr = user.InstitutionNameAr,
            InstitutionTypeAr = user.InstitutionTypeAr,
            CommercialRegistrationDate = user.CommercialRegistrationDate,
            CommercialRegistrationNumber = user.CommercialRegistrationNumber,
            InstitutionNameEn = user.InstitutionNameEn,
            InstitutionTypeEn = user.InstitutionTypeEn,
        };
    }

    public static void UpdateEntity(this Requester requester, RequesterUpdateDto? dto)
    {
        if (dto == null) return;

        requester.InstitutionTypeEn = dto.InstitutionTypeEn ?? requester.InstitutionTypeEn;
        requester.InstitutionTypeAr = dto.InstitutionTypeAr ?? requester.InstitutionTypeAr;
        requester.CommercialRegistrationDate = dto.CommercialRegistrationDate ?? requester.CommercialRegistrationDate;
        requester.CommercialRegistrationNumber = dto.CommercialRegistrationNumber ?? requester.CommercialRegistrationNumber;
        requester.InstitutionNameEn = dto.InstitutionNameEn ?? requester.InstitutionNameEn;
        requester.InstitutionNameAr = dto.InstitutionNameAr ?? requester.InstitutionNameAr;
    }

    public static RequesterDto? ToRequesterDto(this Requester? requester)
    {
        if(requester == null) return null;

        return new RequesterDto
        {
            UserId = requester.UserId,
            FullNameEn = requester.User.FullNameEn,
            FullNameAr = requester.User.FullNameAr,
            Email = requester.User.Email,
            JoiningDate = requester.User.JoiningDate?.ToString("MMM dd, yyyy"),
            PhoneNumber = requester.User.PhoneNumber,
            AddressEn = requester.User.AddressEn,
            AddressAr = requester.User.AddressAr,
            ProfilePictureUrl = requester.User.ProfilePictureUrl,
            InstitutionNameAr = requester.InstitutionNameAr,
            CommercialRegistrationDate = requester.CommercialRegistrationDate?.ToString("MMM dd, yyyy"),
            InstitutionTypeAr = requester.InstitutionTypeAr,
            CommercialRegistrationNumber = requester.CommercialRegistrationNumber,
            InstitutionNameEn = requester.InstitutionNameEn,
            InstitutionTypeEn = requester.InstitutionTypeEn,
            IsActive = requester.User.IsActive
        };
    }

    public static List<RequesterDto> ToRequsterDto(this List<Requester> requesters) =>
        requesters.Select(ToRequesterDto).ToList();
}
