using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class AddSell : Form
    {
        private Client _client;

        public AddSell(ref Client client)
        {
            InitializeComponent();
            _client = client;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckIncorrectData())
                return;

            Selling selling = new(date.Value, textBox1.Text, _client.ID, int.Parse(textBox3.Text));
            _client.Sellings.Add(selling);

            using (Context con = new())
            {
                con.Sellings.Add(selling);
                con.SaveChanges();
            }

            this.Close();
        }

        private bool CheckIncorrectData()
        {
            if (int.TryParse(textBox1.Text, out _))
                return true;

            if (textBox3.Text == "")
                return true;

            return false;
        }
    }
}
