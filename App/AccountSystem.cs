using System;
using System.Threading.Tasks;

namespace App
{
    internal static class AccountSystem
    {
        public static bool IsExist(string email, string pass)
        {
            bool a = false;
            using (Context db = new Context())
            {
                foreach (Client client in db.Clients)
                {
                    if (client.Password == pass && client.Email == email)
                        a = true;
                }
                a = false;
            }
            return a;
        }
        public static bool CheckUniqueEmail(string email)
        {
            using (Context db = new())
            {
                foreach (Client client in db.Clients)
                {
                    if (client.Email == email)
                        return false;
                }
            }
            return true;
        }

        public static bool CheckUniquePhone(string phone)
        {
            using (Context db = new())
            {
                foreach (Client client in db.Clients)
                {
                    if (client.PhoneNumber == phone)
                        return false;
                }
            }
            return true;
        }

        public static void AddNewAccount(Client client)
        {
            using (Context db = new())
            {
                db.Clients.Add(client);
                db.SaveChanges();
            }
        }
    }
}
