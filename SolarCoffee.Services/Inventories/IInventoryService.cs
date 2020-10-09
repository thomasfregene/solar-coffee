using SolarCoffee.Data.Models;
using SolarCoffee.Services.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffee.Services.Inventories
{
    public interface IInventoryService
    {
        List<ProductInventory> GetCurrentInventory();
        ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjustment);
        ProductInventory GetByProductId(int productId);
        void CreateSnapshot();
        List<ProductInventorySnapshot> GetSnapshotHistory();
    }
}
