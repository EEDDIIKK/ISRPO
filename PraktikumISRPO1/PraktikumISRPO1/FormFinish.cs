using System;
using System.Windows.Forms;

namespace TestApp
{
    public partial class FormFinish : Form
    {
        public FormFinish()
        {
            InitializeComponent();
            LoadHistory();
            ShowCurrentResult();
        }

        private void LoadHistory()
        {
            var history = DatabaseHelper.GetUserHistory();
            dgvHistory.DataSource = history;
            if (dgvHistory.Columns.Count > 0)
            {
                dgvHistory.Columns["UserId"].Visible = false;
                dgvHistory.Columns["FirstName"].HeaderText = "Имя";
                dgvHistory.Columns["LastName"].HeaderText = "Фамилия";
                dgvHistory.Columns["TestDate"].HeaderText = "Дата";
                dgvHistory.Columns["CorrectCount"].HeaderText = "Правильно";
                dgvHistory.Columns["TotalCount"].HeaderText = "Всего";
            }
        }

        private void ShowCurrentResult()
        {
            if (dgvHistory.Rows.Count > 0)
            {
                var row = dgvHistory.Rows[0];
                string name = $"{row.Cells["FirstName"].Value} {row.Cells["LastName"].Value}";
                int correct = Convert.ToInt32(row.Cells["CorrectCount"].Value);
                int total = Convert.ToInt32(row.Cells["TotalCount"].Value);
                lblResult.Text = $"{name}, ваш результат: {correct} из {total}";
            }
            else
            {
                lblResult.Text = "Нет результатов";
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите пройти тест заново?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                FormStart start = new FormStart();
                start.Show();
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            FormStart start = Application.OpenForms["FormStart"] as FormStart;
            if (start != null)
                start.Show();
            else
                Application.Exit();
        }
    }
}