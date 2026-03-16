using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using BackpackApp.Database;
using BackpackApp.Debugging;
using BackpackApp.Models;

namespace BackpackApp
{
    public partial class Form1 : Form
    {
        private List<Item> allItems;
        private string connectionString = ConfigurationManager.ConnectionStrings["BackpackDB"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseInitializer.Initialize();
            DatabaseTester.TestConnection();
            LoadOriginalData();
        }

        private void LoadOriginalData()
        {
            using (new ExecutionTimer("Загрузка данных из БД"))
            {
                allItems = new List<Item>();
                string query = "SELECT Id, Name, Weight, Cost FROM objects";
                DebugLogger.LogSqlQuery(query);

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allItems.Add(new Item
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Weight = reader.GetInt32(2),
                                Cost = reader.GetInt32(3)
                            });
                        }
                    }
                }
                DebugLogger.LogItems(allItems, "Загружены предметы");
            }

            ShowItems(allItems);
        }

        private void ShowItems(List<Item> items)
        {
            listViewItems.Items.Clear();
            foreach (var item in items)
            {
                var listItem = new ListViewItem(item.Name);
                listItem.SubItems.Add(item.Weight.ToString());
                listItem.SubItems.Add(item.Cost.ToString());
                listViewItems.Items.Add(listItem);
            }
        }

        private void btnShowOriginal_Click(object sender, EventArgs e)
        {
            ShowItems(allItems);
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxMaxWeight.Text, out int maxWeight) || maxWeight <= 0)
            {
                MessageBox.Show("Введите корректный максимальный вес (целое положительное число).");
                return;
            }

            List<Item> bestCombination = null;
            int bestCost = 0;

            using (new ExecutionTimer("Решение задачи о рюкзаке"))
            {
                int n = allItems.Count;
                int totalCombinations = 1 << n;

                for (int mask = 0; mask < totalCombinations; mask++)
                {
                    int totalWeight = 0;
                    int totalCost = 0;
                    List<Item> current = new List<Item>();

                    for (int i = 0; i < n; i++)
                    {
                        if ((mask & (1 << i)) != 0)
                        {
                            totalWeight += allItems[i].Weight;
                            totalCost += allItems[i].Cost;
                            current.Add(allItems[i]);
                        }
                    }

                    if (totalWeight <= maxWeight && totalCost > bestCost)
                    {
                        bestCost = totalCost;
                        bestCombination = new List<Item>(current);
                    }
                }
            }

            if (bestCombination != null)
            {
                DebugLogger.LogItems(bestCombination, "Лучшее решение");
                ShowItems(bestCombination);
            }
            else
            {
                MessageBox.Show("Не удалось подобрать набор (возможно, все предметы слишком тяжёлые).");
            }
        }
    }
}