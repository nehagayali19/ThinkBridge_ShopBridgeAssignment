using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Models;

namespace Shopbridge_base.Domain.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();

        Task<List<Product>> GetProductById(string productId);

        Task<bool> UpdateProduct(string id, UpdateProduct product);

        Task<bool> AddProduct(Product product);

        Task<bool> DeleteProduct(string id);

    }
}
