using Microsoft.EntityFrameworkCore;

namespace FribergCarRentalsRazorPages.Data
{
    public class AdminRepository : IAdmin
    {

        private readonly ApplicationDbContext applicationDbContext;
        public AdminRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Admin> GetAll()
        {
            return applicationDbContext.Admins.OrderBy(x => x.Id);
        }

        public Admin GetById(int id)
        {
            return applicationDbContext.Admins.FirstOrDefault(x => x.Id == id);
        }

        public void CreateNewAdmin(Admin admin)
        {
            applicationDbContext.Admins.Add(admin);
            applicationDbContext.SaveChanges();
        }

        public void EditAdmin(Admin admin)
        {
            applicationDbContext.Attach(admin).State = EntityState.Modified;
            applicationDbContext.SaveChanges();
        }

        public void DeleteAdmin(Admin admin)
        {
            applicationDbContext.Remove(admin);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<Admin> GetLoggedInAdmin(string email, string password)
        {
            return applicationDbContext.Admins.Where(x => x.Email == email).
                Where(x => x.Password == password);
        }
    }
}

