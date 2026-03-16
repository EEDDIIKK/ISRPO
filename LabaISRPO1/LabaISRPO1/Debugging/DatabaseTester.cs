using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BackpackApp.Debugging
{
    public static class DatabaseTester
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["BackpackDB"].ConnectionString;

        [Conditional("DEBUG")]
        public static void TestConnection()
        {
            try
            {
                DebugLogger.Log("Проверка подключения к базе данных...");
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DebugLogger.Log("Подключение к базе данных успешно установлено");

                    string query = "SELECT COUNT(*) FROM objects";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        int count = (int)cmd.ExecuteScalar();
                        DebugLogger.Log($"В таблице objects найдено {count} записей");
                    }

                    string tablesQuery = @"
                        SELECT TABLE_NAME
                        FROM INFORMATION_SCHEMA.TABLES
                        WHERE TABLE_TYPE = 'BASE TABLE'";
                    using (var tablesCmd = new SqlCommand(tablesQuery, connection))
                    using (var reader = tablesCmd.ExecuteReader())
                    {
                        DebugLogger.Log("Доступные таблицы:");
                        while (reader.Read())
                        {
                            DebugLogger.Log($"  - {reader["TABLE_NAME"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Log($"Ошибка подключения к БД: {ex.Message}");
                DebugLogger.Log($"Stack trace: {ex.StackTrace}");
            }
        }
    }
}