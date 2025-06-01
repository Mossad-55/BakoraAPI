using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BakoraAPI.Entities.Entities;

public class Provider
{
    [Key]
    public Guid? UserId { get; set; }
    public string? InstitutionNameEn { get; set; }
    public string? InstitutionNameAr { get; set; }
    public string? InstitutionTypeEn { get; set; }
    public string? InstitutionTypeAr { get; set; }
    public string? CommercialRegistrationNumber { get; set; }
    public DateTime? CommercialRegistrationDate { get; set; }

    // We should add the Service Id as a foreign key later

    [ForeignKey("UserId")]
    public User? User { get; set; }
}
