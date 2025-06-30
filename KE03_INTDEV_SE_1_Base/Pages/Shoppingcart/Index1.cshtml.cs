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

        public IActionResult OnPostBestellen()
        {
            // Betreft de order van één klant.
            var customer = _context.Customers.FirstOrDefault(c => c.Id == 1);
            if (customer == null || !_context.ShoppingCartItems.Any())
            {
                return RedirectToPage();
            }

            // Maak nieuwe order
            var nieuweOrder = new Order
            {
                Customer = customer,
                OrderDate = DateTime.Now,
                Products = new List<Product>()
            };
            foreach (var item in _context.ShoppingCartItems.ToList())
            {
                var product = _context.Products.FirstOrDefault(p => p.Productnummer == item.Productnummer);
                if (product != null)
                {
                    nieuweOrder.Products.Add(product);
                }
            }

            _context.Orders.Add(nieuweOrder);
            _context.ShoppingCartItems.RemoveRange(_context.ShoppingCartItems); // Winkelwagen leegmaken na bestelling
            _context.SaveChanges();

            return RedirectToPage("/Orderhistory/Index");
        }
    }
}