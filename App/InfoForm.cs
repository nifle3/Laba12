using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class InfoForm : Form
    {
        private Client _client;

        public InfoForm(Client client)
        {
            InitializeComponent();
            _client = client;

            using (Context context = new())
            {
                _client.Sellings = context.Sellings.Where(b => b.ClientId == _client.ID).ToList();
            }

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = _client.Sellings;
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            AddSell form = new(ref _client);
            form.ShowDialog();
        }

        private void InfoForm_Activated(object sender, EventArgs e)
        {
            UpdateSource();
        }

        private void UpdateSource()
        {
            using (Context context = new())
            {
                _client.Sellings = context.Sellings.Where(b => b.ClientId == _client.ID).ToList();
            }
            dataGridView1.DataSource = _client.Sellings;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            Selling? selling = GetSellingByGrid();

            if (selling is null)
                return;

            DeleteSelling(selling);
            UpdateSource();
        }

        private void DeleteSelling(Selling selling)
        {
            using (Context context = new())
            {
                _client.Sellings.Remove(selling);
                context.Sellings.Remove(selling);
                context.SaveChanges();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Selling? selling = GetSellingByGrid();

            if (selling is null)
                return;

            ChangeStatusForm form = new(selling);
            form.ShowDialog();
        }

        private Selling? GetSellingByGrid()
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return null;

            var item = dataGridView1.SelectedRows[0];
            return (Selling)item.DataBoundItem;
        }
    }
}
