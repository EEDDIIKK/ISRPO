using System;

namespace PublishingApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime? CompletionDate { get; set; }
        public decimal Price { get; set; }

        // Метод для генерации названия заказа
        public void GenerateOrderName()
        {
            OrderName = $"Предзаказ #{Id:0000} от {OrderDate:dd.MM.yyyy}";
        }
    }
}