using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace KE03_INTDEV_SE_1_Base.Pages.Orderhistory
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IOrderRepository _orderRepo;

        public IndexModel(ICustomerRepository customerRepo, IOrderRepository orderRepo)
        {
            _customerRepo = customerRepo;
            _orderRepo = orderRepo;
        }

        public List<Customer> Customers { get; set; }
        public IList<Order> Orders { get; set; } = new List<Order>();

        public void OnGet()
        {
            Customers = _customerRepo.GetAllCustomers().ToList();
            Orders = _orderRepo.GetAllOrders().ToList();
        }
    }
}
