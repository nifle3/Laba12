namespace App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            bool isexist = await AccountSystem.isExist(NameTB.Text, PassTb.Text);

            if (!isexist)
                return;

            InfoForm form = new InfoForm();
            form.Show();
        }   

        private void NewAccButton_Click(object sender, EventArgs e)
        {

        }
    }
}