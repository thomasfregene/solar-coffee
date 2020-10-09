using SolarCoffee.Data.Models;
using SolarCoffee.Services.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffee.Services.Order
{
    public class OrderService : IOrderService
    {
        public OrderService()
        {

        }
        public ServiceResponse<bool> GenerateInvoiceForOrder(SalesOrder order)
        {
            throw new NotImplementedException();
        }

        public List<SalesOrder> GetOrders()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> MarkFullFilled(int id)
        {
            throw new NotImplementedException();
        }
    }
}
