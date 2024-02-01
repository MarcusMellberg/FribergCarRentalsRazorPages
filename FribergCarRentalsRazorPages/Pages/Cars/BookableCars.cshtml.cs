using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorPages.Data;
using System.Collections.Immutable;

namespace FribergCarRentalsRazorPages.Pages.Cars
{
    public class BookableCarsModel : PageModel
    {
        private readonly ICar carRepo;
        public BookableCarsModel(ICar carRepo)
        {
            this.carRepo = carRepo;
        }

        

        public IList<Car> Cars { get;set; } = default!;
        public Car Car {  get; set; }

        public async Task OnGetAsync()
        {
            Cars = carRepo.GetAllBookableCars().ToList();
            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ////if (!ModelState.IsValid)
            ////{

            //    return RedirectToPage("./Index");
            //}
            
            //var id = Car.Id;
            //SavedInfoHelper.SetSavedCar(id);
            return RedirectToPage("/Bookings/Create");


            //return RedirectToPage("./Index");
        }
    }
}
