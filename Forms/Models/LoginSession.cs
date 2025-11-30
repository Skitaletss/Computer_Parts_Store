using Computer_Parts_Store.Models;

namespace Computer_Parts_Store.Data
{
    public static class LoginSession
    {
        public static Customer CurrentCustomer { get; private set; }

        public static bool IsLoggedIn => CurrentCustomer != null;

        public static void Login(Customer customer)
        {
            CurrentCustomer = customer;
        }

        public static void Logout()
        {
            CurrentCustomer = null;
        }
    }
}
