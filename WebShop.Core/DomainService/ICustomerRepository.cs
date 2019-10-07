using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.Entity;

namespace WebShop.Core.DomainService
{
    public interface ICustomerRepository
    {
        Customer CreateCustomer(Customer customer);

        Customer DeleteCustomer(int id);

        Customer ReadCustomerById(int id);

        IEnumerable<Customer> ReadCustomers();

        Customer UpdateCustomer(Customer CustomerToUpdate);
    }
}
