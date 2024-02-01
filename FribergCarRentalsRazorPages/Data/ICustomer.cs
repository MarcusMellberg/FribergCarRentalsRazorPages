namespace FribergCarRentalsRazorPages.Data
{
    public interface ICustomer
    {
        Customer GetById(int id);
        IEnumerable<Customer> GetAll();
        void CreateNewCustomer(Customer customer);
        void EditCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        IEnumerable<Customer> GetLoggedInCustomer(string email, string password);
    }
}
