using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Core.DomainService;
using WebShop.Core.DomainService.Filtering;
using WebShop.Core.Entity;

namespace Webshop.Infrastructure.Data.Repositories
{
    class OrderRepository : IOrderRepository
    {
        readonly WebshopAppContext _ctx;

        public OrderRepository(WebshopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Order Create(Order order)
        {
            _ctx.Attach(order).State = EntityState.Added;
            _ctx.SaveChanges();
            return order;
        }

        public Order Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FilteringList<Order> ReadAll(Filter filter)
        {
            if (filter == null)
            {
                return new FilteringList<Order>() { List = _ctx.Orders.ToList(), Count = _ctx.Orders.Count() };
            }

            var items = _ctx.Orders.Include(o => o.OrderList)
                .ThenInclude(ol => ol.Shoe)
                .Include(o => o.Customer)
                .Skip((filter.Page - 1) * filter.Items)
                .Take(filter.Items)
                .ToList();
            return new FilteringList<Order>() { List = items, Count = Count() };
        }

        public int Count()
        {
            return _ctx.Orders.Count();
        }

        public Order ReadById(int id)
        {
            return _ctx.Orders.Include(o => o.Customer)
                .Include(o => o.OrderList)
                .ThenInclude(ol => ol.Shoe)
                .FirstOrDefault(o => o.Id == id);
        }

        public Order Update(Order orderUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
