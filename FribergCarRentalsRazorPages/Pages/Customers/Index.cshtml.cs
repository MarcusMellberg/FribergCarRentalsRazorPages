using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorPages.Data;

namespace FribergCarRentalsRazorPages.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomer customerRepo;
        public IndexModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public IList<Customer> Customer { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = customerRepo.GetAll().ToList();
        }
    }
}
