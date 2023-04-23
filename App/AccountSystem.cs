using System;
using System.Threading.Tasks;

namespace App
{
    internal static class AccountSystem
    {
        public static bool isExist(string email, string pass)
        {
            bool a = false;
            using (Context db = new())
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

        public static async void AddNewAccount(Client client)
        {
            using (Context db = new())
            {
                await Task.Run(() =>
                {
                    db.Clients.Add(client);
                    db.SaveChanges();
                });
            }
        }
    }
}
