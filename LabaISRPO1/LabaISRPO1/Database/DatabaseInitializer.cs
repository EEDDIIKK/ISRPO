using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using BackpackApp.Debugging;

namespace BackpackApp.Database
{
    public static class DatabaseInitializer
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["BackpackDB"].ConnectionString;

        public static void Initialize()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    DebugLogger.Log("База данных уже существует, проверяем наличие таблицы objects...");
                }
                catch (SqlException ex) when (ex.Number == 4060) // База не существует
                {
                    DebugLogger.Log("База данных не найдена, создаём...");
                    CreateDatabase();
                    using (var newConnection = new SqlConnection(connectionString))
                    {
                        newConnection.Open();
                        CreateTablesAndFill(newConnection);
                    }
                    return;
                }

                if (!TableExists(connection, "objects"))
                {
                    CreateTablesAndFill(connection);
                }
                else
                {
                    DebugLogger.Log("Таблица objects уже существует.");
                }
            }
        }

        private static void CreateDatabase()
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            string databaseName = builder.InitialCatalog;
            builder.InitialCatalog = "master";

            using (var conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();
                string createDbQuery = $@"
                    CREATE DATABASE [{databaseName}]
                    ON PRIMARY (NAME = '{databaseName}', FILENAME = '{GetMdfPath(databaseName)}')
                    LOG ON (NAME = '{databaseName}_log', FILENAME = '{GetLdfPath(databaseName)}')";
                using (var cmd = new SqlCommand(createDbQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static string GetMdfPath(string dbName)
        {
            string dataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
            if (!Directory.Exists(dataDir)) Directory.CreateDirectory(dataDir);
            return Path.Combine(dataDir, $"{dbName}.mdf");
        }

        private static string GetLdfPath(string dbName)
        {
            string dataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
            return Path.Combine(dataDir, $"{dbName}_log.ldf");
        }

        private static bool TableExists(SqlConnection connection, string tableName)
        {
            string query = "SELECT COUNT(*) FROM sysobjects WHERE name = @tableName AND xtype = 'U'";
            using (var cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@tableName", tableName);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private static void CreateTablesAndFill(SqlConnection connection)
        {
            DebugLogger.Log("Создание таблицы objects...");
            string createTable = @"
                CREATE TABLE objects (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Name NVARCHAR(50) NOT NULL,
                    Weight INT NOT NULL,
                    Cost INT NOT NULL
                )";
            using (var cmd = new SqlCommand(createTable, connection))
                cmd.ExecuteNonQuery();

            string insertData = @"
                INSERT INTO objects (Name, Weight, Cost) VALUES
                ('Книга', 1, 600),
                ('Бинокль', 2, 5000),
                ('Аптечка', 4, 1500),
                ('Ноутбук', 2, 40000),
                ('Котелок', 1, 500)";
            using (var cmd = new SqlCommand(insertData, connection))
                cmd.ExecuteNonQuery();

            DebugLogger.Log("Таблица objects создана и заполнена.");
        }
    }
}