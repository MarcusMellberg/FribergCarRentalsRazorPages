using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorPages.Data;

namespace FribergCarRentalsRazorPages.Pages.Bookings
{
    public class DeleteModel : PageModel
    {
        private readonly IBooking bookingRepo;
        public DeleteModel(IBooking bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<Booking> bookings = bookingRepo.GetAllBookingsById(id).ToList();
            var booking = bookings.FirstOrDefault();
            if (booking == null)
            {
                return NotFound();
            }
            Booking = booking;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<Booking> bookings = bookingRepo.GetAllBookingsById(id).ToList();
            var booking = bookings.FirstOrDefault();
            Booking = booking;
            Booking.Car.Bookable = true;
            bookingRepo.DeleteBooking(Booking);
            return RedirectToPage("./Index");
        }
    }
}
