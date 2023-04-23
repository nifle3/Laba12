using System;
using System.Collections.Generic;

namespace App
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get;  set; }
        public string Password { get; set; }
        public List<Selling> Sellings { get; set; } = new List<Selling>();

        public Client(string name, string email, string phoneNumber, string password)
        => (Name, Email, PhoneNumber, Password) = (name, email, phoneNumber, password);
    }
}
