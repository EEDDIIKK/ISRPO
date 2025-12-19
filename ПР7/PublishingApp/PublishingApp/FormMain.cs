using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PublishingApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenOrderForm_Click(object sender, EventArgs e)
        {
            using (var orderForm = new FormOrder())
            {
                orderForm.ShowDialog();
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DatabaseHelper())
                {
                    if (db.TestConnection())
                    {
                        MessageBox.Show("Подключение к базе данных успешно!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось подключиться к базе данных", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}