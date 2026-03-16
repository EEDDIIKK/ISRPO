using System;
using System.Windows.Forms;

namespace TestApp
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Введите имя и фамилию.");
                return;
            }

            DatabaseHelper.InitializeDatabase();
            int userId = DatabaseHelper.SaveUser(txtFirstName.Text.Trim(), txtLastName.Text.Trim());

            FormQuestions formQuestions = new FormQuestions(userId);
            formQuestions.Show();
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}