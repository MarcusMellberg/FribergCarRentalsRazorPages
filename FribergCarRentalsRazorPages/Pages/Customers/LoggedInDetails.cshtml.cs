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
    public class LoggedInDetailsModel : PageModel
    {
        private readonly ICustomer customerRepo;
        private readonly IBooking bookingRepo;
        public LoggedInDetailsModel(ICustomer customerRepo,
                IBooking bookingRepo)
        {
            this.customerRepo = customerRepo;
            this.bookingRepo = bookingRepo;
        }

        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customerRepo.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }
    }
}
