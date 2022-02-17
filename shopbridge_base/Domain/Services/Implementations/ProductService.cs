using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using Shopbridge_base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly ShopBridgeContext _dbContext;

        public ProductService(ShopBridgeContext DbContext, ILogger<ProductService> logger)
        {
            _dbContext = DbContext;
            _logger = logger;
        }
       
        public async Task<List<Product>> GetProducts()
        {
            try
            {
                _logger.LogTrace("GetProducts method is called");
                return await _dbContext.Products.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"exception occured in GetProducts method + {ex.Message}");
                throw;
            }
        }

        public async Task<List<Product>> GetProductById(string productId)
        {
            try
            {
                _logger.LogTrace("GetProductById method is called");
                return await _dbContext.Products.Where(x => x.ProductId == productId).ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"exception occured in GetProductById method + {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateProduct(string id, UpdateProduct product)
        {
            try
            {
                _logger.LogTrace("UpdateProduct method is called");
                var details = _dbContext.Products.FirstOrDefault(x => x.ProductId == id);
                if (details != null)
                {
                    details.ProductName = product.ProductName;
                    details.ProductDesciption = product.ProductDesciption;
                    details.ProductColour = product.ProductColour;
                    details.ProductPrice = product.ProductPrice;
                    _dbContext.Products.Update(details);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"exception occured in UpdateProduct method + {ex.Message}");
                throw;
            }
            return false;
        }

        public async Task<bool> AddProduct(Product product)
        {
            try
            {
                _logger.LogTrace("AddProduct method is called");
                if (product.ProductId != null)
                {
                    await _dbContext.Products.AddAsync(product);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"exception occured in UpdateProduct method + {ex.Message}");
                throw;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            try
            {
                _logger.LogTrace("UpdateProduct method is called");
                var details = _dbContext.Products.FirstOrDefault(x => x.ProductId == id);
                if(details != null)
                {
                    _dbContext.Products.Remove(details);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"exception occured in DeleteProduct method + {ex.Message}");
                throw;
            }
            return false;
        }
    }
}
