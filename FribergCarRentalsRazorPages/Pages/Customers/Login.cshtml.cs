using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarRentalsRazorPages.Data;

namespace FribergCarRentalsRazorPages.Pages.Customers
{
    public class LoginModel : PageModel
    {
        private readonly ICustomer customerRepo;
        private readonly IBooking bookingRepo;
        public LoginModel(ICustomer customerRepo,
                IBooking bookingRepo)
        {
            this.customerRepo = customerRepo;
            this.bookingRepo = bookingRepo;
        }
        

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
                var email = Customer.Email;
                var password = Customer.Password;
                var customers = customerRepo.GetLoggedInCustomer(email, password);
                foreach (var customer in customers)
                {
                    int id = customer.Id;
                    SavedInfoHelper.SetLoggedInCustomer(id);
                }
                return RedirectToPage("/Customers/LoggedIn");

        }
    }
}
