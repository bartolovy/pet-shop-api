using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Data.Interfaces;
using PetShop.Data.Models;

namespace PetShop.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("ProductsCategory")]
        public ActionResult<List<Category>> GetProductsCategory()
        {
            var categories = _productService.ProductsCategory.ToList();
            if (categories?.Count == 0)
            {
                return NotFound();
            }
            return categories;
        }
        [HttpGet]
        [Route("ProductsCategory/{categoryId}")]
        public ActionResult<List<Product>> GetProductsByCategoryId(int categoryId)
        {
            var products = _productService.GetProductsByCategoryId(categoryId).ToList();
            if (products?.Count == 0)
            {
                return NotFound();
            }
            return products;
        }
        [HttpGet]
        [Route("Product/{productId}")]
        public ActionResult<Product> GetProduct(int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
    }
}