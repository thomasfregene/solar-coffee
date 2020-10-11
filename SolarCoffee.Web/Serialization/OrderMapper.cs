using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffee.Web.Serialization
{
    /// <summary>
    /// Handles  mapping Order data models to and from related View Models
    /// </summary>
    public static class OrderMapper
    {
        /// <summary>
        /// maps an InvoiceViewModel to a SalesOrder data model
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public static SalesOrder SerializeInvoiceToOrder(InvoiceViewModel invoice)
        {
            var now = DateTime.UtcNow;
            var salesOrderItems = invoice.LineItems
                .Select(item => new SalesOrderItem
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Product = ProductMapper.SerializeProductModel(item.Product)
                }).ToList();
            return new SalesOrder
            {
                SalesOrderItems = salesOrderItems,
                CreatedOn = now,
                UpdatedOn = now
            };
        }
    }
}
