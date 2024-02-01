using Microsoft.EntityFrameworkCore;

namespace FribergCarRentalsRazorPages.Data
{
    public class BookingRepository : IBooking
    {
        private readonly ApplicationDbContext applicationDbContext;
        public BookingRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Booking> GetAll()
        {
            return applicationDbContext.Bookings.OrderBy(x => x.Id)
                .Include(b => b.Customer)
                .Include(b => b.Car);
        }

        public Booking GetById(int id)
        {
            return applicationDbContext.Bookings.FirstOrDefault(x => x.Id == id);
        }

        public void CreateNewBooking(Booking booking)
        {
            applicationDbContext.Bookings.Add(booking);
            applicationDbContext.SaveChanges();
        }

        public void EditBooking(Booking booking)
        {
            applicationDbContext.Attach(booking).State = EntityState.Modified;
            applicationDbContext.SaveChanges();
        }

        public void DeleteBooking(Booking booking)
        {
            applicationDbContext.Remove(booking);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<Booking> GetAllLoggedInBookings(int id)
        {
            return applicationDbContext.Bookings.Where(b => b.Customer.Id == id)
                .Include(b => b.Customer)
                .Include(b => b.Car);
        }
    }
}
