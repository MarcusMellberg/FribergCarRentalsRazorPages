namespace FribergCarRentalsRazorPages.Data
{
    public interface ICar
    {
        Car GetById(int id);
        IEnumerable<Car> GetAll();
        IEnumerable<Car> GetAllBookableCars();
        void CreateNewCar(Car car);
        void EditCar(Car car);
        void DeleteCar(Car car);
    }
}
