using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Core.Entity
{
    public class Shoe
    {
        public int id { get; set; }
        public double  price { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int size { get; set; }
        public string brand { get; set; }
        public string color { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
    }
}

