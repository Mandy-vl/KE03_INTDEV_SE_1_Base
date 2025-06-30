using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace KE03_INTDEV_SE_1_Base.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly MatrixIncDbContext _context;
        private readonly IProductRepository _productRepo;

        public IndexModel(MatrixIncDbContext context, IProductRepository productRepo)
        {
            _context = context;
            _productRepo = productRepo;
        }

        public List<Product> Products { get; set; } = new();

        public void OnGet()
        {
            Products = _productRepo.GetAllProducts().ToList();
        }

        public IActionResult OnPostVoegToeAanWinkelwagen(int productId)
        {
            var product = _productRepo.GetAllProducts().FirstOrDefault(p => p.Productnummer == productId);
            if (product == null) return NotFound();

            var item = new ShoppingCartItem
            {
                Productnummer = product.Productnummer,
                Productnaam = product.Productnaam,
                Omschrijving = product.Omschrijving,
                Kleur = product.Kleur,
                PrijsPerStuk = product.PrijsPerStuk,
                ImageUrl = product.ImageUrl,
            };

            _context.ShoppingCartItems.Add(item);
            _context.SaveChanges();

            return RedirectToPage();
        }

        [BindProperty]
        public int ProductId { get; set; }
    }
}
