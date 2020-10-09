using SolarCoffee.Data.Models;
using SolarCoffee.Services.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffee.Services.Customers
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        ServiceResponse<Customer> CreateCustomer(Customer customer);
        ServiceResponse<bool> DeleteCustomer(int id);
        Customer GetCustomerById(int id);
    }
}
