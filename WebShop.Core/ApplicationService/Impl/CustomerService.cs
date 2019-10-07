using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.Entity;

namespace WebShop.Core.ApplicationService.Impl
{
    public class CustomerService : ICustomerService
    {
        public Customer CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer FindCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public List<Customer> ListSortedByPrice(List<Customer> customers)
        {
            throw new NotImplementedException();
        }

        public Customer NewCustomer(string firstName, string lastName, string address, int zipAddress, int phoneNumber, int age, List<Shoe> cartList)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer customerToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
