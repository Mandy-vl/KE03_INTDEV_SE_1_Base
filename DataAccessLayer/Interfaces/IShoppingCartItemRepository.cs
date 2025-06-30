using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    internal interface IShoppingCartItemRepository
    {
        public IEnumerable<ShoppingCartItem> GetAllShoppingCartItems();

        public ShoppingCartItem? GetShoppingCartItemById(int id);

        public void AddShoppingCartItem(ShoppingCartItem item);

        public void UpdateShoppingCartItem(ShoppingCartItem item);

        public void DeleteShoppingCartItem(int id);

        public void ClearShoppingCart();
    }
}
