using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Core.Entity
{
    public class Customer
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public int zipAddress { get; set; }
        public int phoneNumber { get; set; }
        public int age { get; set; }
        public List<Shoe> cartList { get; set; }
    }
}
