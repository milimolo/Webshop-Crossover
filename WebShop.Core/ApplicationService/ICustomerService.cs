using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.Entity;

namespace WebShop.Core.ApplicationService
{
    public interface ICustomerService
    {
        Customer NewCustomer(string firstName, string lastName, string address, int zipAddress, int phoneNumber, int age, List<Shoe> cartList);

        Customer CreateCustomer(Customer customer);

        Customer Delete(int id);

        Customer FindCustomerById(int id);

        IEnumerable<Customer> GetCustomers();

        Customer Update(Customer customerToUpdate);

        List<Customer> ListSortedByPrice(List<Customer> customers);
    }
}
