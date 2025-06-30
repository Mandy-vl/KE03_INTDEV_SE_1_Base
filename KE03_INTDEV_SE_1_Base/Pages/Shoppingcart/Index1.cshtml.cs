using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace KE03_INTDEV_SE_1_Base.Pages.Shoppingcart
{
    public class Index1Model : PageModel
    {
        private readonly MatrixIncDbContext _context;

        public Index1Model(MatrixIncDbContext context)
        {
            _context = context;
        }

        public IList<ShoppingCartItem> ShoppingCartItems { get; set; }

        public void OnGet()
        {
            ShoppingCartItems = _context.ShoppingCartItems.ToList();
        }
    }
}