using System.Collections.Generic;
using System.Linq;
using Project.Wild.Pony.Domain.Catalog;

namespace Project.Wild.Pony.Domain.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice => Items.Sum(i => i.Price);
    }
}
   