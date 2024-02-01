namespace FribergCarRentalsRazorPages.Data
{
    public class Booking
    {
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public Car? Car { get; set; } = null;
        public int? CostPerDay { get; set; }
        public int? TotalCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? totalDays { get; set; }
    }
}
