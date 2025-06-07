using BakoraAPI.Entities.Entities;
using BakoraAPI.Shared.DTOs.Provider;

namespace BakoraAPI.Services.MappingProfiles;

public static class ProviderMapping
{
    public static Provider? ToEntity(this ProviderRegisterDto? user)
    {
        if(user == null) return null;

        return new Provider
        {
            InstitutionNameAr = user.InstitutionNameAr,
            InstitutionTypeAr = user.InstitutionTypeAr,
            CommercialRegistrationDate = user.CommercialRegistrationDate,
            CommercialRegistrationNumber = user.CommercialRegistrationNumber,
            InstitutionNameEn = user.InstitutionNameEn,
            InstitutionTypeEn = user.InstitutionTypeEn,
        };
    }

    public static void UpdateEntity(this Provider provider, ProviderUpdateDto? dto)
    {
        if(dto  == null) return;

        provider.InstitutionTypeEn = dto.InstitutionTypeEn ?? provider.InstitutionTypeEn;
        provider.InstitutionTypeAr = dto.InstitutionTypeAr ?? provider.InstitutionTypeAr;
        provider.CommercialRegistrationDate = dto.CommercialRegistrationDate ?? provider.CommercialRegistrationDate;
        provider.CommercialRegistrationNumber = dto.CommercialRegistrationNumber ?? provider.CommercialRegistrationNumber;
        provider.InstitutionNameEn = dto.InstitutionNameEn ?? provider.InstitutionNameEn;
        provider.InstitutionNameAr = dto.InstitutionNameAr ?? provider.InstitutionNameAr;
    }

    public static ProviderDto? ToProviderDto(this Provider? provider)
    {
        if(provider == null) return null;

        return new ProviderDto
        {
            UserId = provider.UserId,
            FullNameEn = provider.User.FullNameEn,
            FullNameAr = provider.User.FullNameAr,
            JoiningDate = provider.User.JoiningDate?.ToString("MMM dd, yyyy"),
            Email = provider.User.Email,
            PhoneNumber = provider.User.PhoneNumber,
            AddressEn = provider.User.AddressEn,
            AddressAr = provider.User.AddressAr,
            ProfilePictureUrl = provider.User.ProfilePictureUrl,
            InstitutionNameAr = provider.InstitutionNameAr,
            CommercialRegistrationDate = provider.CommercialRegistrationDate?.ToString("MMM dd, yyyy"),
            InstitutionTypeAr = provider.InstitutionTypeAr,
            CommercialRegistrationNumber = provider.CommercialRegistrationNumber,
            InstitutionNameEn = provider.InstitutionNameEn,
            InstitutionTypeEn = provider.InstitutionTypeEn,
            IsActive = provider.User.IsActive
        };
    }

    public static List<ProviderDto?> ToProviderDto(this List<Provider> providers) =>
        providers.Select(ToProviderDto).ToList();
}
