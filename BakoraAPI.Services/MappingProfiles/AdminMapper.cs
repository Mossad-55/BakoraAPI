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
            FullNameEn = user.User.FullNameEn,
            FullNameAr = user.User.FullNameAr,
            JoiningDate = user.User.JoiningDate?.ToString("MMM dd, yyyy"),
            Email = user.User.Email,
            PhoneNumber = user.User.PhoneNumber,
            AddressEn = user.User.AddressEn,
            AddressAr = user.User.AddressAr,
            ProfilePictureUrl = user.User.ProfilePictureUrl,
            IsActive = user.User.IsActive,
        };
    }

    public static List<AdminDto?> ToAdminDto(this List<Admin> admins) =>
        admins.Select(ToAdminDto).ToList();

}
