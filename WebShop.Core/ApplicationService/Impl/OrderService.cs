using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.DomainService;
using WebShop.Core.DomainService.Filtering;
using WebShop.Core.Entity;

namespace WebShop.Core.ApplicationService.Impl
{
    class OrderService : IOrderService
    {
        readonly IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public Order CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Order FindOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public FilteringList<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public FilteringList<Order> GetFilteredOrders(Filter filter)
        {
            throw new NotImplementedException();
        }

        public Order New()
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrder(Order orderUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
