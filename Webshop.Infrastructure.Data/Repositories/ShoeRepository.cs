﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.DomainService;
using WebShop.Core.Entity;

namespace Webshop.Infrastructure.Data.Repositories
{
    public class ShoeRepository: IShoeRepository
    {
        private readonly WebshopAppContext _ctx; 
        public Shoe CreateShoe(Shoe shoe)
        {
            var ShoeSaved = _ctx.Shoes.Add(shoe).Entity;
            _ctx .SaveChanges();

            return ShoeSaved;
        }

        public Shoe ReadShoeById(int id)
        {
            return _ctx.Shoes 
                .FirstOrDefault(p=>p.id == id);
        }

        public IEnumerable<Shoe> ReadAllShoes()
        {
            return  _ctx.Shoes.ToList();
            
        }


        public Shoe UpdateShoe(Shoe shoeToUpdate)
        {
            _ctx.Attach(shoeToUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return shoeToUpdate;
        }
        

        public Shoe DeleteShoe(int id)
        {
            var shoeRemoved = _ctx.Remove(new Shoe {id = id}).Entity;
            _ctx.SaveChanges();
            return shoeRemoved;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}
