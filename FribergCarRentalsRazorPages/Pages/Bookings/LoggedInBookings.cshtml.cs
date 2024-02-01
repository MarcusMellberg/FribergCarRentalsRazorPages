using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarRentalsRazorPages.Data;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace FribergCarRentalsRazorPages.Pages.Bookings
{
    public class LoggedInBookingsModel : PageModel
    {
        private readonly ICustomer customerRepo;
        private readonly IBooking bookingRepo;
        public LoggedInBookingsModel(ICustomer customerRepo,
                IBooking bookingRepo)
        {
            this.customerRepo = customerRepo;
            this.bookingRepo = bookingRepo;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
           
           Booking = bookingRepo.GetAllLoggedInBookings(SavedInfoHelper.GetLoggedInCustomer()).ToList();
           
        }
    }
}
