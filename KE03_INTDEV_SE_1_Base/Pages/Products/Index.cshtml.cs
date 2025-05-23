using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace KE03_INTDEV_SE_1_Base.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepo;

        public List<Product> Products { get; set; } = new();

        public IndexModel(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public void OnGet()
        {
            Products = _productRepo.GetAllProducts().ToList();
        }

        [BindProperty]
        public int ProductId { get; set; }
    }
}
