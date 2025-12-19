using System;
using System.Windows.Forms;

namespace PublishingApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Проверка подключения к БД перед запуском
            try
            {
                using (var dbHelper = new DatabaseHelper())
                {
                    if (!dbHelper.TestConnection())
                    {
                        MessageBox.Show("Не удалось подключиться к базе данных. Проверьте соединение.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                Application.Run(new MainForm()); // ← ИСПРАВЬ ЭТУ СТРОКУ!
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Критическая ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}