using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffee.Web.ViewModels
{
    /// <summary>
    /// Snapshot view model
    /// </summary>
    public class ProductInventorySnapshotModel
    {
        public List<int> QuantityOnHand { get; set; }
        public int ProductId { get; set; }
    }

    /// <summary>
    /// Snapshot historyin format suitable for graphing
    /// </summary>
    public class SnapshotResponse
    {
        public List<ProductInventorySnapshotModel> productInventorySnapshots { get; set; }
        public List<DateTime> Timeline { get; set; }

    }

}
