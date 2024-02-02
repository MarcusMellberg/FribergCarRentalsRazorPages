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
    public class LoggedInDetailsModel : PageModel
    {
        private readonly IBooking bookingRepo;
        private readonly ICustomer customerRepo;
        public LoggedInDetailsModel(IBooking bookingRepo,
                            ICustomer customerRepo)
        {
            this.bookingRepo = bookingRepo;
            this.customerRepo = customerRepo;
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
            else
            {
                Booking = booking;
            }
            return Page();
        }
    }
}
