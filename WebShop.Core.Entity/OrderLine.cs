using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Core.Entity
{
    public class OrderLine
    {
        public int ShoeId { get; set; }
        public Shoe Shoe { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Qty { get; set; }
        public double TotalPrice { get; set; }
    }
}
