using System;

namespace App
{
    public class Selling
    {
        public int ID { set; get; }
        public DateTime Date { set; get; }
        public string Goods { set; get; }
        public int ClientId { set; get; }
        public Client Client { set; get; } 
        public int Quantity { set; get; }

        public Selling(DateTime date, string goods, int clientId, int quantity) =>
            (Date, Goods, ClientId, Quantity) = (date, goods, clientId, quantity);
    }
}
