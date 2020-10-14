using PetShop.Data.Models;
using System.Collections.Generic;

namespace PetShop.Data.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Category> ProductsCategory { get; }
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
        Product GetProductById(int productId);
        bool UpdateProductsStock(List<ShoppingCartItem> shoppingCartItems);
        bool ValidateProductsStock(List<ShoppingCartItem> shoppingCartItems);
    }
}
