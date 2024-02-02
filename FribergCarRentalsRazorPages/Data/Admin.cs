using System.ComponentModel.DataAnnotations;

namespace FribergCarRentalsRazorPages.Data
{
    public class Admin
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Firstname is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(5, ErrorMessage = "Password needs to be atleast 5 characters")]
        public string Password { get; set; }
    }
}
