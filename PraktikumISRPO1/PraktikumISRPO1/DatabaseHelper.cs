using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace TestApp
{
    public static class DatabaseHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        private static bool DatabaseExists()
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            string server = builder.DataSource;
            string database = builder.InitialCatalog;
            string masterConnection = $"Data Source={server};Initial Catalog=master;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(masterConnection))
            {
                conn.Open();
                string query = $"SELECT COUNT(*) FROM sys.databases WHERE name = '{database}'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                    return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private static void CreateDatabase()
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            string server = builder.DataSource;
            string database = builder.InitialCatalog;
            string dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
            if (!Directory.Exists(dataDirectory))
                Directory.CreateDirectory(dataDirectory);
            string mdfPath = Path.Combine(dataDirectory, $"{database}.mdf");
            string ldfPath = Path.Combine(dataDirectory, $"{database}_log.ldf");
            string masterConnection = $"Data Source={server};Initial Catalog=master;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(masterConnection))
            {
                conn.Open();
                string createDbQuery = $@"
                    CREATE DATABASE [{database}]
                    ON PRIMARY (NAME = '{database}', FILENAME = '{mdfPath}')
                    LOG ON (NAME = '{database}_log', FILENAME = '{ldfPath}')";
                using (SqlCommand cmd = new SqlCommand(createDbQuery, conn))
                    cmd.ExecuteNonQuery();
            }
        }

        private static bool TableExists(SqlConnection connection, string tableName)
        {
            string query = "SELECT COUNT(*) FROM sysobjects WHERE name = @tableName AND xtype = 'U'";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@tableName", tableName);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private static bool ColumnExists(SqlConnection connection, string tableName, string columnName)
        {
            string query = @"
                SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS 
                WHERE TABLE_NAME = @tableName AND COLUMN_NAME = @columnName";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@tableName", tableName);
                cmd.Parameters.AddWithValue("@columnName", columnName);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private static void DropAllTables(SqlConnection connection)
        {
            string[] tables = { "UserAnswers", "Users", "Questions" };
            foreach (string table in tables)
            {
                if (TableExists(connection, table))
                {
                    using (SqlCommand cmd = new SqlCommand($"DROP TABLE [{table}]", connection))
                        cmd.ExecuteNonQuery();
                }
            }
        }

        private static void CreateAllTables(SqlConnection connection)
        {
            string createUsers = @"
                CREATE TABLE Users (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    FirstName NVARCHAR(50) NOT NULL,
                    LastName NVARCHAR(50) NOT NULL,
                    TestDate DATETIME NOT NULL
                )";
            using (SqlCommand cmd = new SqlCommand(createUsers, connection))
                cmd.ExecuteNonQuery();

            string createQuestions = @"
                CREATE TABLE Questions (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Text NVARCHAR(500) NOT NULL,
                    Option1 NVARCHAR(200) NOT NULL,
                    Option2 NVARCHAR(200) NOT NULL,
                    Option3 NVARCHAR(200) NOT NULL,
                    Option4 NVARCHAR(200) NOT NULL,
                    CorrectOption INT NOT NULL CHECK (CorrectOption BETWEEN 1 AND 4)
                )";
            using (SqlCommand cmd = new SqlCommand(createQuestions, connection))
                cmd.ExecuteNonQuery();

            string createUserAnswers = @"
                CREATE TABLE UserAnswers (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id) ON DELETE CASCADE,
                    QuestionId INT NOT NULL FOREIGN KEY REFERENCES Questions(Id),
                    SelectedOption INT NOT NULL,
                    IsCorrect BIT NOT NULL
                )";
            using (SqlCommand cmd = new SqlCommand(createUserAnswers, connection))
                cmd.ExecuteNonQuery();
        }

        private static void SeedQuestions(SqlConnection connection)
        {
            // Удаляем все существующие вопросы (чтобы гарантированно заменить их нашими)
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Questions", connection))
                cmd.ExecuteNonQuery();

            // Сбрасываем счётчик автоинкремента (ID начнутся с 1)
            using (SqlCommand cmd = new SqlCommand("DBCC CHECKIDENT ('Questions', RESEED, 0)", connection))
                cmd.ExecuteNonQuery();

            // Настоящие вопросы по программированию
            var questions = new[]
            {
                new { Text = "Что такое .NET Framework?", Option1 = "Язык программирования", Option2 = "Среда выполнения и библиотека классов", Option3 = "Операционная система", Option4 = "Текстовый редактор", Correct = 2 },
                new { Text = "Какой тип данных в C# предназначен для хранения целых чисел?", Option1 = "float", Option2 = "double", Option3 = "int", Option4 = "string", Correct = 3 },
                new { Text = "Что означает аббревиатура ООП?", Option1 = "Объектно-ориентированное программирование", Option2 = "Оператор обработки ошибок", Option3 = "Основы описания программ", Option4 = "Общая область памяти", Correct = 1 },
                new { Text = "Какой модификатор доступа делает член класса доступным только внутри этого класса?", Option1 = "public", Option2 = "internal", Option3 = "protected", Option4 = "private", Correct = 4 },
                new { Text = "Что такое наследование в ООП?", Option1 = "Возможность создавать класс на основе другого класса", Option2 = "Скрытие данных", Option3 = "Перегрузка методов", Option4 = "Обработка событий", Correct = 1 },
                new { Text = "Какой цикл выполняется хотя бы один раз, независимо от условия?", Option1 = "for", Option2 = "while", Option3 = "do-while", Option4 = "foreach", Correct = 3 },
                new { Text = "Что такое массив?", Option1 = "Набор однотипных элементов с доступом по индексу", Option2 = "Функция для сортировки данных", Option3 = "Класс для работы со строками", Option4 = "Тип данных для хранения одного значения", Correct = 1 },
                new { Text = "Какая конструкция используется для обработки исключений в C#?", Option1 = "if-else", Option2 = "switch", Option3 = "try-catch-finally", Option4 = "using", Correct = 3 },
                new { Text = "Что такое конструктор класса?", Option1 = "Метод, который вызывается при создании объекта", Option2 = "Метод для удаления объекта", Option3 = "Свойство класса", Option4 = "Поле класса", Correct = 1 },
                new { Text = "Какой модификатор позволяет переопределить виртуальный метод в производном классе?", Option1 = "override", Option2 = "new", Option3 = "virtual", Option4 = "abstract", Correct = 1 },
                new { Text = "Что такое интерфейс в C#?", Option1 = "Класс, содержащий только абстрактные методы", Option2 = "Контракт, определяющий набор методов и свойств, которые должен реализовать класс", Option3 = "Структура данных", Option4 = "Событие", Correct = 2 },
                new { Text = "Какой тип возвращает метод Main по умолчанию?", Option1 = "int", Option2 = "void", Option3 = "string", Option4 = "bool", Correct = 2 },
                new { Text = "Что такое свойство в C#?", Option1 = "Переменная класса", Option2 = "Метод для доступа к полям с логикой get/set", Option3 = "Тип данных", Option4 = "Событие", Correct = 2 },
                new { Text = "Какое ключевое слово используется для создания нового объекта?", Option1 = "new", Option2 = "create", Option3 = "object", Option4 = "this", Correct = 1 },
                new { Text = "Что делает сборщик мусора в .NET?", Option1 = "Удаляет неиспользуемые объекты и освобождает память", Option2 = "Собирает статистику использования памяти", Option3 = "Управляет потоками", Option4 = "Компилирует код", Correct = 1 }
            };

            string insertQuestion = @"
                INSERT INTO Questions (Text, Option1, Option2, Option3, Option4, CorrectOption)
                VALUES (@Text, @Option1, @Option2, @Option3, @Option4, @CorrectOption)";

            foreach (var q in questions)
            {
                using (SqlCommand cmd = new SqlCommand(insertQuestion, connection))
                {
                    cmd.Parameters.AddWithValue("@Text", q.Text);
                    cmd.Parameters.AddWithValue("@Option1", q.Option1);
                    cmd.Parameters.AddWithValue("@Option2", q.Option2);
                    cmd.Parameters.AddWithValue("@Option3", q.Option3);
                    cmd.Parameters.AddWithValue("@Option4", q.Option4);
                    cmd.Parameters.AddWithValue("@CorrectOption", q.Correct);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void InitializeDatabase()
        {
            if (!DatabaseExists())
                CreateDatabase();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                bool needsRebuild = false;
                if (TableExists(connection, "Users") && ColumnExists(connection, "Users", "StartTime"))
                    needsRebuild = true;

                if (needsRebuild)
                {
                    DropAllTables(connection);
                    CreateAllTables(connection);
                }
                else
                {
                    if (!TableExists(connection, "Users"))
                        CreateAllTables(connection);
                    else if (!ColumnExists(connection, "Users", "TestDate"))
                    {
                        using (SqlCommand cmd = new SqlCommand("ALTER TABLE Users ADD TestDate DATETIME NOT NULL DEFAULT GETDATE()", connection))
                            cmd.ExecuteNonQuery();
                    }

                    if (!TableExists(connection, "Questions"))
                    {
                        string createQuestions = @"
                            CREATE TABLE Questions (
                                Id INT IDENTITY(1,1) PRIMARY KEY,
                                Text NVARCHAR(500) NOT NULL,
                                Option1 NVARCHAR(200) NOT NULL,
                                Option2 NVARCHAR(200) NOT NULL,
                                Option3 NVARCHAR(200) NOT NULL,
                                Option4 NVARCHAR(200) NOT NULL,
                                CorrectOption INT NOT NULL CHECK (CorrectOption BETWEEN 1 AND 4)
                            )";
                        using (SqlCommand cmd = new SqlCommand(createQuestions, connection))
                            cmd.ExecuteNonQuery();
                    }

                    if (!TableExists(connection, "UserAnswers"))
                    {
                        string createUserAnswers = @"
                            CREATE TABLE UserAnswers (
                                Id INT IDENTITY(1,1) PRIMARY KEY,
                                UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id) ON DELETE CASCADE,
                                QuestionId INT NOT NULL FOREIGN KEY REFERENCES Questions(Id),
                                SelectedOption INT NOT NULL,
                                IsCorrect BIT NOT NULL
                            )";
                        using (SqlCommand cmd = new SqlCommand(createUserAnswers, connection))
                            cmd.ExecuteNonQuery();
                    }
                }

                // ВСЕГДА перезаписываем вопросы настоящими
                SeedQuestions(connection);
            }
        }

        public static int SaveUser(string firstName, string lastName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insert = "INSERT INTO Users (FirstName, LastName, TestDate) OUTPUT INSERTED.Id VALUES (@FirstName, @LastName, @TestDate)";
                using (SqlCommand cmd = new SqlCommand(insert, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@TestDate", DateTime.Now);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public static List<Question> GetQuestions()
        {
            List<Question> questions = new List<Question>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string select = "SELECT Id, Text, Option1, Option2, Option3, Option4, CorrectOption FROM Questions";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        questions.Add(new Question
                        {
                            Id = reader.GetInt32(0),
                            Text = reader.GetString(1),
                            Options = new string[] { reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5) },
                            CorrectOption = reader.GetInt32(6)
                        });
                    }
                }
            }
            return questions;
        }

        public static void SaveUserAnswer(int userId, int questionId, int selectedOption, bool isCorrect)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insert = "INSERT INTO UserAnswers (UserId, QuestionId, SelectedOption, IsCorrect) VALUES (@UserId, @QuestionId, @SelectedOption, @IsCorrect)";
                using (SqlCommand cmd = new SqlCommand(insert, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@QuestionId", questionId);
                    cmd.Parameters.AddWithValue("@SelectedOption", selectedOption);
                    cmd.Parameters.AddWithValue("@IsCorrect", isCorrect);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<UserResult> GetUserHistory()
        {
            List<UserResult> history = new List<UserResult>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT u.Id, u.FirstName, u.LastName, u.TestDate,
                           COUNT(CASE WHEN ua.IsCorrect = 1 THEN 1 END) AS CorrectCount,
                           COUNT(ua.Id) AS TotalCount
                    FROM Users u
                    LEFT JOIN UserAnswers ua ON u.Id = ua.UserId
                    GROUP BY u.Id, u.FirstName, u.LastName, u.TestDate
                    ORDER BY u.TestDate DESC";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        history.Add(new UserResult
                        {
                            UserId = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            TestDate = reader.GetDateTime(3),
                            CorrectCount = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                            TotalCount = reader.IsDBNull(5) ? 0 : reader.GetInt32(5)
                        });
                    }
                }
            }
            return history;
        }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string[] Options { get; set; }
        public int CorrectOption { get; set; }
    }

    public class UserResult
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime TestDate { get; set; }
        public int CorrectCount { get; set; }
        public int TotalCount { get; set; }
    }
}