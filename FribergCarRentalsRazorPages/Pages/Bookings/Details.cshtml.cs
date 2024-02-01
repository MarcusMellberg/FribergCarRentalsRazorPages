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
    public class DetailsModel : PageModel
    {
        private readonly IBooking bookingRepo;
        private readonly ICustomer customerRepo;
        public DetailsModel(IBooking bookingRepo, 
                            ICustomer customerRepo)
        {
            this.bookingRepo = bookingRepo;
            this.customerRepo = customerRepo;
        }
        [BindProperty]
        public Booking Booking { get; set; } = default!;
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = bookingRepo.GetById(id);
            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                Booking = booking;
                Customer = Booking.Customer;
            }
            return Page();
        }
    }
}
