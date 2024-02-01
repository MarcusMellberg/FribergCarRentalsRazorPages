using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarRentalsRazorPages.Data;

namespace FribergCarRentalsRazorPages.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly IBooking bookingRepo;
        private readonly ICustomer customerRepo;
        private readonly ICar carRepo;
        public CreateModel(IBooking bookingRepo,
                           ICustomer customerRepo,
                           ICar carRepo)
        {
            this.bookingRepo = bookingRepo;
            this.customerRepo = customerRepo;
            this.carRepo = carRepo;
        }

        public IActionResult OnGet(int id)
        {
            var car = id;
            SavedInfoHelper.SetSavedCar(id);
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Booking.Customer = customerRepo.GetById(SavedInfoHelper.GetLoggedInCustomer());
            Booking.Car = carRepo.GetById(SavedInfoHelper.GetSavedCar());
            Booking.CostPerDay = Booking.Car.RentPricePerDay;
            Booking.TotalCost = Booking.CostPerDay * Booking.totalDays;
            var car = Booking.Car;
            car.Bookable = false;
            carRepo.EditCar(car);
            bookingRepo.CreateNewBooking(Booking);
            return RedirectToPage("./Index");
        }
    }
}
