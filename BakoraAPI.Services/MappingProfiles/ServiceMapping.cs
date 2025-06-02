using BakoraAPI.Entities.Entities;
using BakoraAPI.Shared.DTOs.Service;

namespace BakoraAPI.Services.MappingProfiles;

public static class ServiceMapping
{
    public static Service? ToEntity(this ServiceCreateDto? dto)
    {
        if (dto == null) return null;

        return new Service
        {
            DescriptionAr = dto.DescriptionAr,
            TitleAr = dto.TitleAr,
            DescriptionEn = dto.DescriptionEn,
            TitleEn = dto.TitleEn
        };
    }

    public static void UpdateEntity(this Service service, ServiceUpdateDto dto)
    {
        if (dto == null) return;

        service.DescriptionAr = dto.DescriptionAr ?? service.DescriptionAr;
        service.DescriptionEn = dto.DescriptionEn ?? service.DescriptionEn;
        service.TitleEn = dto.TitleEn ?? service.TitleEn;
        service.TitleAr = dto.TitleAr ?? service.TitleAr;
    }

    public static ServiceDto? ToServiceDto(this Service? service)
    {
        if (service == null) return null;

        return new ServiceDto
        {
            Id = service.Id,
            DescriptionAr = service.DescriptionAr,
            TitleAr = service.TitleAr,
            DescriptionEn = service.DescriptionEn,
            TitleEn = service.TitleEn
        };
    }

    public static List<ServiceDto?> ToServiceDto(this List<Service> services) =>
        services.Select(ToServiceDto).ToList();
}
