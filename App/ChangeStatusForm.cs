using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace App
{
    public partial class ChangeStatusForm : Form
    {
        private Selling _selling;

        public ChangeStatusForm(Selling selling)
        {
            InitializeComponent();
            _selling = selling;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string status = StatusChoose();

            using (Context context = new())
            {
                _selling.Status = status;
                context.Sellings.Update(_selling);
                context.SaveChanges();
            }

                this.Close();
        }

        private string StatusChoose()
        {
            if (radioButton1.Checked)
                return "отправлено";

            else if (radioButton2.Checked)
                return "доставлено";

            else if (radioButton3.Checked)
                return "получено";

             return _selling.Status;
        }
    }
}
