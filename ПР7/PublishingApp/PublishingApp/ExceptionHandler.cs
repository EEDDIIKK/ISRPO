using System;
using System.Windows.Forms;

namespace PublishingApp
{
    public static class ExceptionHandler
    {
        public static void HandleException(Exception ex, string context = "")
        {
            string message = $"Произошла ошибка";

            if (!string.IsNullOrEmpty(context))
                message += $" в {context}";

            message += $":\n{ex.Message}";

            if (ex.InnerException != null)
                message += $"\n\nВнутренняя ошибка: {ex.InnerException.Message}";

            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Логирование ошибки
            LogException(ex, context);
        }

        private static void LogException(Exception ex, string context)
        {
            string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {context}\n" +
                               $"Тип: {ex.GetType().Name}\n" +
                               $"Сообщение: {ex.Message}\n" +
                               $"Стек вызовов: {ex.StackTrace}\n" +
                               "----------------------------------------\n";

            // Запись в файл
            try
            {
                System.IO.File.AppendAllText("error_log.txt", logMessage);
            }
            catch
            {
                // Если не удалось записать в файл, игнорируем
            }
        }
    }
}