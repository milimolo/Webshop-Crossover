using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.DomainService.Filtering;
using WebShop.Core.Entity;

namespace WebShop.Core.DomainService
{
    public interface IOrderRepository
    {
        Order Create(Order order);

        Order ReadById(int id);

        //Filtered list og filters
        FilteringList<Order> ReadAll(Filter filter);

        Order Update(Order orderUpdate);

        Order Delete(int id);
    }
}
