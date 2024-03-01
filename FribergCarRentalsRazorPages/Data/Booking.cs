using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRentalsRazorPages.Data
{
    public class Booking
    {
        [DisplayName("Booking Id")]
        public int Id { get; set; }

        public Customer? Customer { get; set; }

        public Car? Car { get; set; } = null;

        [DisplayName("Cost per day")]
        public int? CostPerDay { get; set; }

        [DisplayName("Total cost")]
        public int? TotalCost { get; set; }

        [DisplayName("Start date")]
        [Required(ErrorMessage = "Startdate is required")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        [Required(ErrorMessage = "Enddate is required")]
        public DateTime EndDate { get; set; }

        [DisplayName("Total days")]
        public int? totalDays { get; set; }
    }
}
