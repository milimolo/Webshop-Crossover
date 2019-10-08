using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.DomainService;
using WebShop.Core.DomainService.Filtering;
using WebShop.Core.Entity;

namespace Webshop.Infrastructure.Data.Repositories
{
    public class ShoeRepository: IShoeRepository
    {
        private readonly WebshopAppContext _ctx; 

        public ShoeRepository(WebshopAppContext context)
        {
            _ctx = context;
        }

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

        public FilteringList<Shoe> ReadAllShoes(Filter filter = null)
        {
            var query = _ctx.Set<Shoe>();

            if (filter == null)
            {
                return new FilteringList<Shoe>()
                {
                    List = _ctx.Shoes.ToList(),
                    Count = _ctx.Shoes.Count()
                };
            }

                var page = query
                .Select(e => e)
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage)
                .GroupBy(e => new { Total = query.Count() })
                .FirstOrDefault();

                if (page != null)
                {
                    var total = page.Key.Total;
                    var items = page.Select(e => e).ToList();
                    return new FilteringList<Shoe>() { List = items, Count = total };
                }
                return new FilteringList<Shoe>()
                {
                    List = new List<Shoe>(),
                    Count = 0
                };
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
