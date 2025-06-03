using BakoraAPI.Entities.Entities;
using BakoraAPI.Shared.DTOs.Order;
using BakoraAPI.Shared.DTOs.Service;

namespace BakoraAPI.Services.MappingProfiles;

public static class OrderMapping
{
    public static Order? ToEntity(this Order order)
    {
        if (order == null) return null;

        return new Order
        {
            OrderStatus = order.OrderStatus,
            OrderNo = order.OrderNo,
            ServiceType = order.ServiceType,
            Notes = order.Notes,
            DeliveryAddress = order.DeliveryAddress,
            PaymentMethod = order.PaymentMethod,
            PhoneNumber = order.PhoneNumber,
            OrderDate=DateTime.Now,
            OrderTotal= order.OrderTotal
        };
    }

    public static void UpdateEntity(this Order order, OrderDTO dto)
    {
        if (dto == null) return;

        order.Notes = dto.Notes ?? order.Notes;
        order.OrderNo = dto.OrderNo ?? order.OrderNo;
        order.DeliveryAddress = dto.DeliveryAddress ?? order.DeliveryAddress;
        order.PaymentMethod = dto.PaymentMethod ?? order.PaymentMethod;
        order.OrderStatus = dto.OrderStatus ?? order.OrderStatus;
        order.OrderTotal = dto.OrderTotal ?? order.OrderTotal;
        order.ServiceType = dto.ServiceType ?? order.ServiceType;
        order.PhoneNumber = dto.PhoneNumber ?? order.PhoneNumber;
        order.OrderDate = DateTime.Now;

    }

    //public static ServiceDto? ToServiceDto(this Service? service)
    //{
    //    if (service == null) return null;

    //    return new ServiceDto
    //    {
    //        Id = service.Id,
    //        DescriptionAr = service.DescriptionAr,
    //        TitleAr = service.TitleAr,
    //        DescriptionEn = service.DescriptionEn,
    //        TitleEn = service.TitleEn
    //    };
    //}

    //public static List<ServiceDto?> ToServiceDto(this List<Service> services) =>
    //    services.Select(ToServiceDto).ToList();
}
