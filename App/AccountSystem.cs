using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal static class AccountSystem
    {
        public static async Task<bool> isExist(string email, string pass)
        {
            bool a = false;

            using (Context db = new())
            {
                await Task.Run(() =>
                {
                    foreach (Client client in db.Clients)
                    {
                        if (client.Password == pass && client.Email == email)
                            a = true;
                    }
                    a = false;
                });
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
