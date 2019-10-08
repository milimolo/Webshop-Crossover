using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.Entity;

namespace Webshop.Infrastructure.Data
{
    public class WebshopAppContext: DbContext
    {
        public WebshopAppContext(DbContextOptions opt): base(opt)
        {

        }

        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
    }
}
