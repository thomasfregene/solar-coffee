using SolarCoffee.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffee.Web.ViewModels
{
    /// <summary>
    /// View model for Open SalesOrder
    /// </summary>
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
        public List<SalesOrderItemModel> LineItems { get; set; }
    }

    /// <summary>
    /// View model for Open SalesOrderItems
    /// </summary>
    public class SalesOrderItemModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ProductViewModel Product { get; set; }

    }
}
