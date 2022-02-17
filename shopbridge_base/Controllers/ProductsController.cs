using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using Shopbridge_base.Models;

namespace Shopbridge_base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _iLogger;

        public ProductsController(IProductService productService, ILogger<ProductsController> iLogger)
        {
            this._productService = productService;
            this._iLogger = iLogger;
        }

       
        [HttpGet]   
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                _iLogger.LogTrace("GetProducts API is called");
                var productsList = await _productService.GetProducts();
                return productsList;
            }
            catch(Exception ex)
            {
                _iLogger.LogError($"Exception Occured in GetProducts API call + {ex.Message}");
                throw;
            }
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductById(string id)
        {
            try
            {
                _iLogger.LogTrace("GetProductById API is called");
                var productById = await _productService.GetProductById(id);
                return productById;
            }
            catch(Exception ex)
            {
                _iLogger.LogError($"Exception Occured in GetProductById API call + {ex.Message}");
                throw;
            }
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, UpdateProduct product)
        {
            try
            {
                _iLogger.LogTrace("UpdateProduct API is called");
                if (product != null)
                {
                    bool message =await _productService.UpdateProduct(id, product);
                    if (message)
                    {
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _iLogger.LogError($"Exception Occured in UpdateProduct API call + {ex.Message}");
                throw;
            }
        }

        
        [HttpPost]
        public async Task<IActionResult> PostProduct(Product product)
        {
            try
            {
                _iLogger.LogTrace("PostProduct API is called");
                if (product != null)
                {
                    bool message = await _productService.AddProduct(product);
                    if(message)
                    {
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _iLogger.LogError($"Exception Occured in UpdateProduct API call + {ex.Message}");
                throw;
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            try
            {
                _iLogger.LogTrace("PostProduct API is called");
                if (id != null)
                {
                    bool message = await _productService.DeleteProduct(id);
                    if(message)
                    {
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                _iLogger.LogError($"Exception Occured in DeleteProduct API call + {ex.Message}");
                throw;
            }
        }
    }
}
