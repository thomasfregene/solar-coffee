using SolarCoffee.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffee.Services.Products
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        ServiceResponse<Product> CreateProduct(Product product);
        ServiceResponse<Product> IsArchiveProduct(int id);
    }
}
