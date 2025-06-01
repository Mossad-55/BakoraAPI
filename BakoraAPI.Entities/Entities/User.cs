using Microsoft.AspNetCore.Identity;

namespace BakoraAPI.Entities.Entities;

public class User : IdentityUser<Guid>
{
    public string? FullNameEn { get; set; }
    public string? FullNameAr { get; set; }
    public string? AddressEn { get; set; }
    public string? AddressAr { get; set; }
    public string? ProfilePictureUrl { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryDate { get; set; }

    // Roles Profiles
    public virtual Admin? Admin { get; set; }
    public virtual Provider? Provider { get; set; }
    public virtual Requester? Requester { get; set; }
}
