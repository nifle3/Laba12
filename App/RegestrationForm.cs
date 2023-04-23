using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Configuration;

namespace App
{
    public partial class RegestrationForm : Form
    {
        public RegestrationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckIncorrectDate())
                return;

            string hashPass = HashPass.GetHashString(pass.Text);

            Client client = new(name.Text, email.Text, phone.Text, hashPass);

            AccountSystem.AddNewAccount(client);
            this.Close();
        }

        private bool CheckIncorrectDate()
        {
            if (name.Text == "" || phone.Text == "" || name.Text == "" || pass.Text == "")
                return true;

                if (!EmailCheck() || !AccountSystem.CheckUniqueEmail(email.Text))
                    return true;

            if (!CheckCorrectPhoneNumber() || !AccountSystem.CheckUniqueEmail(phone.Text))
                return true;

            return false;

        }

        private bool EmailCheck() =>
            Regex.IsMatch(email.Text, @"\S+@\S+.\S+", RegexOptions.None);

        private bool CheckCorrectPhoneNumber() =>
           Regex.IsMatch(phone.Text, @"[+][0-9]\d+", RegexOptions.None) ||
           Regex.IsMatch(phone.Text, @"\d+", RegexOptions.None);
    }
}
