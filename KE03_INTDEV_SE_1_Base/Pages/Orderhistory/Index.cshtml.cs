using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;
using DataAccessLayer.Interfaces;

namespace KE03_INTDEV_SE_1_Base.Pages.Orderhistory
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerRepository _customerRepo;

        public IndexModel(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public List<Customer> Customers { get; set; } = new();

        public void OnGet()
        {
            Customers = _customerRepo.GetAllCustomers().ToList();
        }
    }
}
