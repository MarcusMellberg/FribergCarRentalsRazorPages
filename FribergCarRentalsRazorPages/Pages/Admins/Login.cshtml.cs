using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarRentalsRazorPages.Data;

namespace FribergCarRentalsRazorPages.Pages.Admins
{
    public class LoginModel : PageModel
    {
        private readonly ICustomer customerRepo;
        private readonly IBooking bookingRepo;
        private readonly IAdmin adminRepo;
        public LoginModel(ICustomer customerRepo,
                IBooking bookingRepo,
                IAdmin adminRepo)
        {
            this.customerRepo = customerRepo;
            this.bookingRepo = bookingRepo;
            this.adminRepo = adminRepo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Admin Admin { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var email = Admin.Email;
            var password = Admin.Password;
            var admins = adminRepo.GetLoggedInAdmin(email, password);
            foreach (var admin in admins)
            {
                if (admin == null)
                {
                    return NotFound();
                }
                else
                {
                    int id = admin.Id;
                    SavedInfoHelper.SetLoggedInAdmin(id);
                    return RedirectToPage("/Admins/LoggedIn");
                }
            }
        return RedirectToPage("/Admins/Login");
        }
    }
}
