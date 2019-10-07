using System;
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

        public List<Shoe> ReadAllShoes()
        {
            return  _ctx.Shoes.ToList();
            
        }


        public Shoe UpdateShoe(Shoe shoeToUpdate)
        {
            throw new NotImplementedException();
        }
        

        public Shoe DeleteShoe(int id)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}
