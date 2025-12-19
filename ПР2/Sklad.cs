using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SkladApp
{
    public partial class Sklad : Form
    {
        private DatabaseHelper dbHelper;
        private DataTable productsTable;

        public Sklad()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadProducts();
        }

        private void LoadProducts()
        {
            productsTable = dbHelper.GetProducts();
            dataGridViewProducts.DataSource = productsTable;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow != null)
            {
                DataGridViewRow row = dataGridViewProducts.CurrentRow;
                int id = Convert.ToInt32(row.Cells["id"].Value);
                string name = row.Cells["name"].Value.ToString();
                int stillage = Convert.ToInt32(row.Cells["stillage"].Value);
                int cell = Convert.ToInt32(row.Cells["cell"].Value);
                int quantity = Convert.ToInt32(row.Cells["quantity"].Value);

                if (dbHelper.UpdateProduct(id, name, stillage, cell, quantity))
                {
                    MessageBox.Show("Продукт успешно обновлен!");
                    LoadProducts();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells["id"].Value);
                if (MessageBox.Show("Вы уверены, что хотите удалить этот продукт?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (dbHelper.DeleteProduct(id))
                    {
                        MessageBox.Show("Продукт успешно удален!");
                        LoadProducts();
                    }
                }
            }
        }

        private void btnSearchByName_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchByName.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                DataTable result = dbHelper.SearchByName(searchText);
                dataGridViewProducts.DataSource = result;
            }
            else
            {
                LoadProducts();
            }
        }

        private void btnSearchByCoords_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtStillage.Text, out int stillage) && int.TryParse(txtCell.Text, out int cell))
            {
                DataTable result = dbHelper.SearchByCoordinates(stillage, cell);
                dataGridViewProducts.DataSource = result;
            }
            else
            {
                MessageBox.Show("Введите корректные значения для стеллажа и ячейки!");
            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Сохранить данные о продуктах";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine("ID\tНазвание\tСтеллаж\tЯчейка\tКоличество");
                    foreach (DataRow row in productsTable.Rows)
                    {
                        writer.WriteLine($"{row["id"]}\t{row["name"]}\t{row["stillage"]}\t{row["cell"]}\t{row["quantity"]}");
                    }
                }
                MessageBox.Show("Данные успешно сохранены в файл!");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
            txtSearchByName.Clear();
            txtStillage.Clear();
            txtCell.Clear();
        }

        private void Sklad_Load(object sender, EventArgs e)
        {

        }
    }
}