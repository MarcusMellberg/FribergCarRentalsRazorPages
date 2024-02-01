using Microsoft.EntityFrameworkCore;

namespace FribergCarRentalsRazorPages.Data
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext applicationDbContext;
        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Customer> GetAll()
        {
            return applicationDbContext.Customers.OrderBy(x => x.Id);
        }


        public Customer GetById(int id)
        {
            return applicationDbContext.Customers.FirstOrDefault(x => x.Id == id);
        }

        public void CreateNewCustomer(Customer customer)
        {
            applicationDbContext.Customers.Add(customer);
            applicationDbContext.SaveChanges();
        }

        public void EditCustomer(Customer customer)
        {
            applicationDbContext.Attach(customer).State = EntityState.Modified;
            applicationDbContext.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            applicationDbContext.Remove(customer);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetLoggedInCustomer(string email, string password)
        {
            return applicationDbContext.Customers.Where(x => x.Email == email).
                Where(x => x.Password == password);
        }

    }
}
