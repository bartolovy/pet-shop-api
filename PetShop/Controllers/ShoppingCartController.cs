using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Data.Interfaces;
using PetShop.Data.Models;
using PetShop.ViewModels;

namespace PetShop.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController( IProductService productService, ShoppingCart shoppingCart)
        {
            _productService = productService;
            _shoppingCart = shoppingCart;
        }

        [HttpGet]
        [Route("ShoppingCart")]
        public ActionResult<ShoppingCartModel> GetShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            ShoppingCartModel result = new ShoppingCartModel() { ShoppingCartItems = new List<ShoppingCartItemModel>() };
            foreach (var item in items)
            {
                result.ShoppingCartItems.Add(new ShoppingCartItemModel() { 
                    Amount = item.Amount,
                    NumberOfItemsInStock = item.Product.NumberOfItemsInStock,
                    Price = item.Product.Price,
                    ProductName = item.Product.Name,
                    ProductId = item.Product.Id,
                    IsOutOfStock = item.Amount > item.Product.NumberOfItemsInStock,
                    Total = item.Amount * item.Product.Price
                });
            }
            result.Total = result.ShoppingCartItems.Sum(i => i.Total);
            result.TotalItems = result.ShoppingCartItems.Sum(i => i.Amount);
            return result;
        }

        [HttpPost]
        [Route("ShoppingCart/Add")]
        public ActionResult AddToShoppingCart([FromBody]ShoppingCartAddItemModel model)
        {
            var selectedProduct = _productService.Products.FirstOrDefault(p => p.Id == model.ProductId);

            if(selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct, model.Amount);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("ShoppingCart/Remove/{productId}")]
        public ActionResult RemoveFromShoppingCart(int productId)
        {
            var selectedProduct = _productService.Products.FirstOrDefault(p => p.Id == productId);

            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [Route("ShoppingCart/Buy")]
        public ActionResult Buy()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            if (_productService.ValidateProductsStock(items) && _productService.UpdateProductsStock(items))
            {
                _shoppingCart.ResetCart();
                return Ok();
            }
            else
                return BadRequest();
        }
    }
}