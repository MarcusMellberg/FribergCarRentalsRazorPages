using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorPages.Data;

namespace FribergCarRentalsRazorPages.Pages.Admins
{
    public class IndexModel : PageModel
    {
        private readonly IAdmin adminRepo;
        public IndexModel(IAdmin adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        public IList<Admin> Admin { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Admin = adminRepo.GetAll().ToList();
        }
    }
}
