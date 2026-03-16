using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FilesApp
{
    public partial class SimbolsCount : Form
    {
        // Строка подключения из App.config
        private string connectionString = ConfigurationManager.ConnectionStrings["FileHistoryDB"].ConnectionString;

        public SimbolsCount()
        {
            InitializeComponent();
        }

        // Открытие файла
        private void btnOpen_Click(object sender, EventArgs e)
        {
            // Точка останова 1 — начало открытия файла
            System.Diagnostics.Debug.WriteLine("Начало открытия файла");

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Точка останова 2 — файл выбран
                    System.Diagnostics.Debug.WriteLine($"Выбран файл: {openFileDialog.FileName}");
                    txtPath.Text = openFileDialog.FileName;

                    try
                    {
                        // Точка останова 3 — чтение файла
                        string content = File.ReadAllText(openFileDialog.FileName);
                        // Точка останова 4 — отображение текста
                        txtText.Text = content;
                        System.Diagnostics.Debug.WriteLine($"Прочитано символов: {content.Length}");

                        // Сохраняем в историю операцию открытия
                        SaveToDatabase(txtPath.Text, content, content.Length, "Открытие");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при чтении файла: {ex.Message}");
                        System.Diagnostics.Debug.WriteLine($"Ошибка чтения: {ex.Message}");
                    }
                }
            }
        }

        // Подсчёт символов (кнопка)
        private void btnCountUp_Click(object sender, EventArgs e)
        {
            // Точка останова 5 — подсчёт символов
            int count = txtText.Text.Length;
            txtCount.Text = count.ToString();
            System.Diagnostics.Debug.WriteLine($"Подсчитано символов: {count}");
        }

        // Автоматический подсчёт при изменении текста (для удобства)
        private void txtText_TextChanged(object sender, EventArgs e)
        {
            // Можно автоматически обновлять счётчик, но по заданию есть отдельная кнопка
            // Оставляем, как опцию (можно закомментировать)
            // txtCount.Text = txtText.Text.Length.ToString();
        }

        // Сохранение файла
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                // Если путь не указан, предлагаем сохранить как
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        txtPath.Text = saveFileDialog.FileName;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            try
            {
                File.WriteAllText(txtPath.Text, txtText.Text);
                MessageBox.Show("Файл успешно сохранён.");
                // Сохраняем в историю операцию сохранения
                SaveToDatabase(txtPath.Text, txtText.Text, txtText.Text.Length, "Сохранение");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Ошибка сохранения: {ex.Message}");
            }
        }

        // Очистка полей
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtText.Clear();
            txtCount.Clear();
            txtPath.Clear();
        }

        // Выход с подтверждением
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Подтверждение закрытия формы
        private void SimbolsCount_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        // Сохранение операции в базу данных (создаёт таблицу, если её нет)
        private void SaveToDatabase(string filePath, string content, int symbolCount, string operationType)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    // Точка останова 6 — подключение к БД
                    connection.Open();

                    // Проверяем, существует ли таблица FileOperations
                    string checkTableQuery = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='FileOperations' AND xtype='U')
                        BEGIN
                            CREATE TABLE FileOperations (
                                Id INT PRIMARY KEY IDENTITY(1,1),
                                FilePath NVARCHAR(500),
                                Content NVARCHAR(MAX),
                                SymbolCount INT,
                                OperationType NVARCHAR(50),
                                OperationDate DATETIME DEFAULT GETDATE()
                            )
                        END";
                    using (var checkCommand = new SqlCommand(checkTableQuery, connection))
                    {
                        checkCommand.ExecuteNonQuery();
                    }

                    // Вставляем запись об операции
                    string insertQuery = @"
                        INSERT INTO FileOperations (FilePath, Content, SymbolCount, OperationType)
                        VALUES (@FilePath, @Content, @SymbolCount, @OperationType)";
                    using (var command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FilePath", filePath ?? "Без пути");
                        command.Parameters.AddWithValue("@Content", content ?? "");
                        command.Parameters.AddWithValue("@SymbolCount", symbolCount);
                        command.Parameters.AddWithValue("@OperationType", operationType);
                        command.ExecuteNonQuery();
                    }

                    System.Diagnostics.Debug.WriteLine($"Операция '{operationType}' сохранена в БД");
                }
            }
            catch (Exception ex)
            {
                // Записываем ошибку в отладочный вывод, но не показываем пользователю
                System.Diagnostics.Debug.WriteLine($"Ошибка при сохранении в БД: {ex.Message}");
            }
        }
    }
}