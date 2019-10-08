using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.DomainService.Filtering;
using WebShop.Core.Entity;

namespace WebShop.Core.ApplicationService
{
    public interface IOrderService
    {
        Order New();

        //Create //POST
        Order CreateOrder(Order order);
        //Read //GET
        Order FindOrderById(int id);
        FilteringList<Order> GetAll();
        FilteringList<Order> GetFilteredOrders(Filter filter);
        //Update //PUT
        Order UpdateOrder(Order orderUpdate);

        //Delete //DELETE
        Order DeleteOrder(int id);
    }
}
