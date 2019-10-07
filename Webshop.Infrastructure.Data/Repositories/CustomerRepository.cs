using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.DomainService;
using WebShop.Core.Entity;

namespace Webshop.Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Customer ReadCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> ReadCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(Customer CustomerToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
