namespace FribergCarRentalsRazorPages.Data
{
    public interface IAdmin
    {
        Admin GetById(int id);
        IEnumerable<Admin> GetAll();
        void CreateNewAdmin(Admin admin);
        void EditAdmin(Admin admin);
        void DeleteAdmin(Admin admin);
        IEnumerable<Admin> GetLoggedInAdmin(string email, string password);
    }
}
