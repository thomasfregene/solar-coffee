using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffee.Web.Serialization
{
    public class ProductMapper
    {
        /// <summary>
        /// Maps a product data model to a ProductModel view model
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static ProductViewModel SerializeProductModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                CreatedOn = product.CreatedOn,
                UpdatedOn = product.UpdatedOn,
                Price = product.Price,
                Name = product.Name,
                Description = product.Description,
                IsTaxable = product.IsTaxable,
                IsArchived = product.IsArchived
            };
        }

        /// <summary>
        /// Maps a ProductModel view model to a  Product data model 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static Product SerializeProductModel(ProductViewModel product)
        {
            return new Product
            {
                Id = product.Id,
                CreatedOn = product.CreatedOn,
                UpdatedOn = product.UpdatedOn,
                Price = product.Price,
                Name = product.Name,
                Description = product.Description,
                IsTaxable = product.IsTaxable,
                IsArchived = product.IsArchived
            };
        }
    }
}
