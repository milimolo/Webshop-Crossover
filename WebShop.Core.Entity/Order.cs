using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Core.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<OrderLine> OrderList { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
