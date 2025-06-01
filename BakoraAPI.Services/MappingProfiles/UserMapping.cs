using BakoraAPI.Entities.Entities;
using BakoraAPI.Shared.DTOs.Admin;
using BakoraAPI.Shared.DTOs.Provider;

namespace BakoraAPI.Services.MappingProfiles;

public static class UserMapping
{
    public static User? ToUserEntity(this AdminRegisterDto? dto)
    {
        if (dto == null) return null;

        return new User
        {
            UserName = dto.Email,
            AddressAr = dto.AddressAr,
            AddressEn = dto.AddressEn,
            Email = dto.Email,
            FullNameEn = dto.FullNameEn,
            FullNameAr = dto.FullNameAr,
            PhoneNumber = dto.PhoneNumber,
            ProfilePictureUrl = dto.ProfilePictureUrl
        };
    }

    public static User? ToUserEntity(this ProviderRegisterDto? dto)
    {
        if (dto == null) return null;

        return new User
        {
            UserName = dto.Email,
            AddressAr = dto.AddressAr,
            AddressEn = dto.AddressEn,
            Email = dto.Email,
            FullNameEn = dto.FullNameEn,
            FullNameAr = dto.FullNameAr,
            PhoneNumber = dto.PhoneNumber,
            ProfilePictureUrl = dto.ProfilePictureUrl
        };
    }

    public static void UpdateEntity(this User user, AdminUpdateDto dto)
    {
        if (dto == null) return;

        user.PhoneNumber = dto.PhoneNumber ?? user.PhoneNumber;
        user.FullNameAr = dto.FullNameAr ?? user.FullNameAr;
        user.FullNameEn = dto.FullNameEn ?? user.FullNameEn;
        user.AddressEn = dto.AddressEn ?? user.AddressEn;
        user.AddressAr = dto.AddressAr ?? user.AddressAr;
        user.ProfilePictureUrl = dto.ProfilePictureUrl ?? user.ProfilePictureUrl;
    }

    public static void UpdateEntity(this User user, ProviderUpdateDto dto)
    {
        if(dto == null) return;

        user.PhoneNumber = dto.PhoneNumber ?? user.PhoneNumber;
        user.FullNameAr = dto.FullNameAr ?? user.FullNameAr;
        user.FullNameEn = dto.FullNameEn ?? user.FullNameEn;
        user.AddressEn = dto.AddressEn ?? user.AddressEn;
        user.AddressAr = dto.AddressAr ?? user.AddressAr;
        user.ProfilePictureUrl = dto.ProfilePictureUrl ?? user.ProfilePictureUrl;
    }
}
