using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakoraAPI.Shared.DTOs.Order
{
    public class OrderDTO
    {
            public string OrderNo { get; set; }
            public decimal? OrderTotal { get; set; }
            public string OrderStatus { get; set; }
            public string ServiceType { get; set; }
            public string? DeliveryAddress { get; set; }
            public string PaymentMethod { get; set; }
            public DateTime OrderDate { get; set; }
            public string? Notes { get; set; }
            public string? PhoneNumber { get; set; }
        

    }
}
