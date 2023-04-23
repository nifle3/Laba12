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
    public partial class InfoForm : Form
    {
        private Client client;

        public InfoForm(Client client)
        {
            InitializeComponent();
            this.client = client;
            using (Context con = new()) 
            {
                dataGridView1.DataSource = con.Sellings;
            }
        }
    }
}
