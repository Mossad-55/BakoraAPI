using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakoraAPI.Entities.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string OrderNo { get; set; } = null!;
        public decimal? OrderTotal { get; set; }
        public string OrderStatus { get; set; } = null!;
        public string ServiceType { get; set; } = null!;       
        public string? DeliveryAddress { get; set; }           
        public string PaymentMethod { get; set; } = null!;    
        public DateTime OrderDate { get; set; }               
        public string? Notes { get; set; }                    
        public string? PhoneNumber { get; set; }               

        // Navigation properties
        public User User { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
