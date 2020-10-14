using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.ViewModels
{
    public class ShoppingCartModel
    {
        public double Total { get; set; }
        public int TotalItems { get; set; }
        public List<ShoppingCartItemModel> ShoppingCartItems { get; set; }
    }
}
