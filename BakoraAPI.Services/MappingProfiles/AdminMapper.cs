using BakoraAPI.Entities.Entities;
using BakoraAPI.Shared.DTOs.Admin;

namespace BakoraAPI.Services.MappingProfiles;

public static class UserMapper
{
    public static AdminDto ToAdminDto(this Admin user)
    {
        if (user == null) return null;

        return new AdminDto
        {
            UserId = user.UserId,
            FullNameEnglish = user.User.FullNameEn,
            FullNameArabic = user.User.FullNameEn,
            Email = user.User.Email,
            PhoneNumber = user.User.PhoneNumber,
            AddressEnglish = user.User.AddressEn,
            AddressArabic = user.User.AddressAr,
            ProfilePictureUrl = user.User.ProfilePictureUrl
        };
    }

    public static List<AdminDto?> ToAdminDto(this List<Admin> admins) =>
        admins.Select(ToAdminDto).ToList();

}
