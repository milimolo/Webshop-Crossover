using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.Entity;

namespace Webshop.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void Seed(WebshopAppContext wac)
        {
           // wac.Database.EnsureDeleted();
            //wac.Database.EnsureCreated();

            Shoe shoe1 = new Shoe()
            {
                name = "Hot Heels",
                price = 1000,
                description = "Perfect shoe for running",
                color = "Black",
                brand = "Nike",
                size = 40,
                type = "Herre",
                date = DateTime.Today.AddDays(-5)
            };

            Shoe shoe2 = new Shoe()
            {
                name = "Off the Court",
                price = 700,
                description = "Leave the competition in the dust",
                color = "White",
                brand = "Adidas",
                size = 39,
                type = "Herre",
                date = DateTime.Today.AddDays(-10)
            };

            Shoe shoe3 = new Shoe()
            {
                name = "Nice Walkers",
                price = 900,
                description = "Shoe great for a long walk",
                color = "Red",
                brand = "Puma",
                size = 35,
                type = "Kvinde",
                date = DateTime.Today.AddDays(-1)
            };

            shoe1 = wac.Shoes.Add(shoe1).Entity;
            shoe2 = wac.Shoes.Add(shoe2).Entity;
            shoe3 = wac.Shoes.Add(shoe3).Entity;

            wac.SaveChanges();

        }
    }
}
