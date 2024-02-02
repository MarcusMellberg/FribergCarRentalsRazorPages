using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorPages.Data;

namespace FribergCarRentalsRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICar carRepo;
        public IndexModel(ILogger<IndexModel> logger, ICar carRepo)
        {
            _logger = logger;
            this.carRepo = carRepo;
        }
        [BindProperty]
        public IList<Car> Car { get; set; } = default!;
        public void OnGet()
        {
            Car = carRepo.GetAll().ToList();
        }
    }
}
