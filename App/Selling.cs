using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class Selling
    {
        public int ID { set; get; }
        public DateTime Date { set; get; }
        public string Goods { set; get; }
        public int ClientId { set; get; }
        public Client Client { set; get; } 
        public int Quantity { set; get; }
    }
}
