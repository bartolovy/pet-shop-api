using Microsoft.EntityFrameworkCore;
using PetShop.Data.Interfaces;
using PetShop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _appDbContext;
        public ProductService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> ProductsCategory => _appDbContext.Categories;
        public IEnumerable<Product> Products => _appDbContext.Products;
        public IEnumerable<Product> GetProductsByCategoryId(int categoryId) => _appDbContext.Products.Where(p => p.CategoryId == categoryId);
        public Product GetProductById(int productId) => _appDbContext.Products.FirstOrDefault(p => p.Id == productId);
        public bool UpdateProductsStock(List<ShoppingCartItem> shoppingCartItems)
        {
            try
            {
                foreach (var item in shoppingCartItems)
                {
                    _appDbContext.Products.First(p => p.Id == item.Product.Id).NumberOfItemsInStock -= item.Amount;
                }
                _appDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ValidateProductsStock(List<ShoppingCartItem> shoppingCartItems)
        {
            for (int i = 0; i < shoppingCartItems.Count; i++)
            {
                if (shoppingCartItems[i].Amount > shoppingCartItems[i].Product.NumberOfItemsInStock)
                    return false;
            }
            return true;
        }
    }
}
