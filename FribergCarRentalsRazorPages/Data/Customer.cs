using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRentalsRazorPages.Data
{
    public class Customer
    {
        [DisplayName("Customer Id")]
        public int Id { get; set; }

        [DisplayName("Firstname")]
        [Required(ErrorMessage = "Firstname is required")]
        public string FirstName { get; set; }

        [DisplayName("Lastname")]
        [Required(ErrorMessage = "Lastname is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(5, ErrorMessage = "Password needs to be atleast 5 characters")]
        public string Password { get; set; }

        public virtual List<Booking>? Bookings { get; set; }
    }
}
