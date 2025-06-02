namespace BakoraAPI.Shared.DTOs.Service;

public record ServiceDto
{
    public Guid? Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
}
