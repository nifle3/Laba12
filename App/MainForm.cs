namespace App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isexist;
            Client? client;
            (isexist, client) = AccountSystem.IsExist(NameTB.Text, PassTb.Text);

            if (!isexist)
                return;

            InfoForm form = new(client);
            form.ShowDialog();
        }   

        private void NewAccButton_Click(object sender, EventArgs e)
        {
            RegestrationForm form = new();
            form.ShowDialog();
        }
    }
}