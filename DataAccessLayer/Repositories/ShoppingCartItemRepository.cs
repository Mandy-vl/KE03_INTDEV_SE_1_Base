using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    internal class ShoppingCartItemRepository
    {
        private readonly MatrixIncDbContext _context;
        public ShoppingCartItemRepository(MatrixIncDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ShoppingCartItem> GetAllShoppingCartItems()
        {
            return _context.ShoppingCartItems.ToList();
        }
        public ShoppingCartItem? GetShoppingCartItemById(int id)
        {
            return _context.ShoppingCartItems.FirstOrDefault(s => s.Productnummer == id);
        }
    }
}
