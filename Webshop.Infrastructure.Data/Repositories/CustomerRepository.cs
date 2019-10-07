using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.DomainService;
using WebShop.Core.Entity;

namespace Webshop.Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly WebshopAppContext _ctx; 
        public Customer CreateCustomer(Customer customer)
        {
            var custSaved = _ctx.Customers .Add(customer).Entity;
            _ctx .SaveChanges();

            return custSaved;
            
        }

        public Customer DeleteCustomer(int id)
        {
            var custRemoved = _ctx.Remove(new Customer {id = id}).Entity;
            _ctx.SaveChanges();
            return custRemoved;
        }

        public Customer ReadCustomerById(int id)
        {
            return _ctx.Customers  
                .FirstOrDefault(p=>p.id == id);
        }

        public IEnumerable<Customer> ReadCustomers()
        {
            return  _ctx.Customers.ToList();
        }

        public Customer UpdateCustomer(Customer CustomerToUpdate)
        {
            _ctx.Attach(CustomerToUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return CustomerToUpdate;
        }
    }
}
