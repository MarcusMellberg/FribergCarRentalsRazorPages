using FribergCarRentalsRazorPages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergCarRentalsRazorPages.Pages.Admins
{
    public class LoggedInModel : PageModel
    {

        private readonly IAdmin adminRepo;
        public LoggedInModel(IAdmin adminRepo)
        {
            this.adminRepo = adminRepo;
        }
        [BindProperty]
        public Admin Admin { get; set; } = default!;

        public IActionResult OnGet()
        {
            var admin = adminRepo.GetById(SavedInfoHelper.GetLoggedInAdmin());
            Admin = admin;
            return Page();
        }

        
    }
}
