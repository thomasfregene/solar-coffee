using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffee.Web.Serialization
{
    public static class CustomerMapper
    {
        /// <summary>
        /// serializes a customer data model into customerModel view model
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static CustomerModel SerializeCustomer(Customer customer)
        {
            //var address = new CustomerAddressModel
            //{
            //    Id = customer.Id,
            //    AddressLine1 = customer.PrimaryAddress.AddressLine1,
            //    AddressLine2 = customer.PrimaryAddress.AddressLine2,
            //    City = customer.PrimaryAddress.City,
            //    State = customer.PrimaryAddress.State,
            //    Country = customer.PrimaryAddress.Country,
            //    PostalCode = customer.PrimaryAddress.PostalCode,
            //    CreatedOn = customer.PrimaryAddress.CreatedOn,
            //    UpdatedOn = customer.PrimaryAddress.UpdatedOn
            //};

            return new CustomerModel
            {
                Id = customer.Id,
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PrimaryAddress = MapCustomerAddress(customer.PrimaryAddress),

            };
        }

        /// <summary>
        /// serializes a customerModel view model into customer data model 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Customer SerializeCustomer(CustomerModel customer)
        {
            //var address = new CustomerAddress
            //{
            //    Id = customer.Id,
            //    AddressLine1 = customer.PrimaryAddress.AddressLine1,
            //    AddressLine2 = customer.PrimaryAddress.AddressLine2,
            //    City = customer.PrimaryAddress.City,
            //    State = customer.PrimaryAddress.State,
            //    Country = customer.PrimaryAddress.Country,
            //    PostalCode = customer.PrimaryAddress.PostalCode,
            //    CreatedOn = customer.PrimaryAddress.CreatedOn,
            //    UpdatedOn = customer.PrimaryAddress.UpdatedOn
            //};

            return new Customer
            {
                Id = customer.Id,
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PrimaryAddress = MapCustomerAddress(customer.PrimaryAddress),

            };
        }

        /// <summary>
        /// Maps CustomerAddress data model to CustomerAddressModel view Model
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static CustomerAddressModel MapCustomerAddress(CustomerAddress address)
        {
            return new CustomerAddressModel
            {
                Id = address.Id,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                State = address.State,
                PostalCode = address.PostalCode,
                Country = address.Country,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Maps CustomerAddressModel view Model to CustomerAddress data model
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static CustomerAddress MapCustomerAddress(CustomerAddressModel address)
        {
            return new CustomerAddress
            {
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                State = address.State,
                PostalCode = address.PostalCode,
                Country = address.Country,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };
        }
    }
}
