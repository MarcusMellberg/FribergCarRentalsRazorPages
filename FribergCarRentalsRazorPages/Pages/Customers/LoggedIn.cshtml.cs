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
    public class LoggedInModel : PageModel
    {
        private readonly ICustomer customerRepo;
        private readonly IBooking bookingRepo;
        public LoggedInModel(ICustomer customerRepo,
                IBooking bookingRepo)
        {
            this.customerRepo = customerRepo;
            this.bookingRepo = bookingRepo;
        }
        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public IActionResult OnGet()
        {
            var customer = customerRepo.GetById(SavedInfoHelper.GetLoggedInCustomer());
            Customer = customer;
            return Page();
        }

    }

}
