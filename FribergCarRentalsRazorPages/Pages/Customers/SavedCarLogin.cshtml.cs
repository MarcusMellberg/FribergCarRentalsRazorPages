using FribergCarRentalsRazorPages.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergCarRentalsRazorPages.Pages.Customers
{
    public class SavedCarLoginModel : PageModel
    {
        private readonly ICustomer customerRepo;
        private readonly IBooking bookingRepo;
        public SavedCarLoginModel(ICustomer customerRepo,
                IBooking bookingRepo)
        {
            this.customerRepo = customerRepo;
            this.bookingRepo = bookingRepo;
        }


        public IActionResult OnGet(int id)
        {
            var car = id;
            SavedInfoHelper.SetSavedCar(id);
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var email = Customer.Email;
            var password = Customer.Password;
            var customers = customerRepo.GetLoggedInCustomer(email, password);
            foreach (var customer in customers)
            {
                int id = customer.Id;
                SavedInfoHelper.SetLoggedInCustomer(id);
            }
            return RedirectToPage("/Bookings/CustomerCreate");

        }
    }
}
