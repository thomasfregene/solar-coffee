using Microsoft.Extensions.Configuration;
using SolarCoffee.Data.Models;
using SolarCoffee.Services.Customers;
using SolarCoffee.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffee.Web.ADO.NETDb
{
    public class CustomerServiceADONET : ICustomerService
    {
        public ServiceResponse<Customer> CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
