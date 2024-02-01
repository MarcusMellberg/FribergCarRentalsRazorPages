namespace FribergCarRentalsRazorPages.Data
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int RentPricePerDay { get; set; }
        public bool Bookable { get; set; }
        public string Image {  get; set; }
    }
}
