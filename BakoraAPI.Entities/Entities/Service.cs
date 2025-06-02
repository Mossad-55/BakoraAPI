using System.ComponentModel.DataAnnotations;

namespace BakoraAPI.Entities.Entities;

public class Service
{
    [Key]
    public Guid Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
}
