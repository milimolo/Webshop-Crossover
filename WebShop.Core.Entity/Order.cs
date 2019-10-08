using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Core.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public List<OrderLine> OrderList { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
