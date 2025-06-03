using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakoraAPI.Entities.Entities
{
    public class Medicines
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpDate { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Type { get; set; } = null!;

        // Navigation properties
        public ICollection<Cart> Carts { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
