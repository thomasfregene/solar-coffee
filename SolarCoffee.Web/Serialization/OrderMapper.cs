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

        /// <summary>
        /// Maps the collection of salesOrder to OrderModel
        /// </summary>
        /// <param name="orderItems"></param>
        /// <returns></returns>
        public static List<OrderModel> SerializeOrdersToViewModels(IEnumerable<SalesOrder> orders)
        {
            return orders.Select(order => new OrderModel()
            {
                Id = order.Id,
                CreatedOn = order.CreatedOn,
                SalesOrderItems = (List<SalesOrderItem>)SerializesSalesOrderItems(order.SalesOrderItems),
                Customer = CustomerMapper.SerializeCustomer(order.Customer),
                IsPaid = order.IsPaid
            }).ToList();
        }

        /// <summary>
        /// Maps the collection of salesOrderItems to salesOrderItemModel
        /// </summary>
        /// <param name="orderItems"></param>
        /// <returns></returns>
        private static IEnumerable<SalesOrderItemModel> SerializesSalesOrderItems(IEnumerable<SalesOrderItem> orderItems)
        {
            return orderItems.Select(item => new SalesOrderItemModel()
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Product = ProductMapper.SerializeProductModel(item.Product)
            }).ToList();
        }
    }
}
