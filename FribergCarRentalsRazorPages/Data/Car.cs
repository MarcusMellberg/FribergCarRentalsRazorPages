using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRentalsRazorPages.Data
{
    public class Car
    {
        [DisplayName("Car Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Brand is required")]

        public string Brand { get; set; }

        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }

        [DisplayName("Rent price per day")]
        public int RentPricePerDay { get; set; }

        [Required(ErrorMessage = "If the car is bookable is required")]
        [UIHint("Bookable")]
        public bool Bookable { get; set; }

        public string Image {  get; set; }
    }
}
