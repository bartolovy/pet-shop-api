using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.ViewModels
{
    public class ShoppingCartItemModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public double Total { get; set; }
        public int NumberOfItemsInStock { get; set; }
        public bool IsOutOfStock { get; set; }
    }
}
