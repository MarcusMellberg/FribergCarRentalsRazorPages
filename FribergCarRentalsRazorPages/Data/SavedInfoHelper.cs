namespace FribergCarRentalsRazorPages.Data
{
    public static class SavedInfoHelper
    {
        private static int LoggedInCustomer  { get; set; }
        private static int SavedCar {  get; set; }
        private static int LoggedInAdmin {  get; set; }

        public static void SetLoggedInCustomer(int id)
        {
            LoggedInCustomer = id;
        }

        public static void SetSavedCar(int id)
        {
            SavedCar = id;
        }

        public static void SetLoggedInAdmin(int id)
        {
            LoggedInAdmin = id;
        }

        public static int GetLoggedInCustomer() 
        { 
            return LoggedInCustomer;
        }

        public static int GetSavedCar() 
        { 
            return SavedCar;
        }

        public static int GetLoggedInAdmin()
        {
            return LoggedInAdmin;
        }
    }
}
