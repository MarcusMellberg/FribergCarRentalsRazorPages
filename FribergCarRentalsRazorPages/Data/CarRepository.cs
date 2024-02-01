using Microsoft.EntityFrameworkCore;

namespace FribergCarRentalsRazorPages.Data
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Car> GetAll()
        {
            return applicationDbContext.Cars.OrderBy(x => x.Id);
        }

        public IEnumerable<Car> GetAllBookableCars()
        {
            List<Car> cars = new List<Car>();
            foreach (Car car in applicationDbContext.Cars)
            {
                if (car.Bookable == true)
                {
                    cars.Add(car);
                }

            }
            return cars;
        }

        public Car GetById(int id)
        {
            return applicationDbContext.Cars.FirstOrDefault(x => x.Id == id);
        }

        public void CreateNewCar(Car car)
        {
            applicationDbContext.Cars.Add(car);
            applicationDbContext.SaveChanges();
        }

        public void EditCar(Car car)
        {
            applicationDbContext.Attach(car).State = EntityState.Modified;
            applicationDbContext.SaveChanges();
        }

        public void DeleteCar(Car car) 
        { 
            applicationDbContext.Remove(car);
            applicationDbContext.SaveChanges();
        }
    }
}
