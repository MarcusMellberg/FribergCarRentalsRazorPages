namespace FribergCarRentalsRazorPages.Data
{
    public interface IBooking
    {
        Booking GetById(int id);
        IEnumerable<Booking> GetAll();
        void CreateNewBooking(Booking booking);
        void EditBooking(Booking booking);
        void DeleteBooking(Booking booking);
        IEnumerable<Booking> GetAllLoggedInBookings(int id);

    }
}
