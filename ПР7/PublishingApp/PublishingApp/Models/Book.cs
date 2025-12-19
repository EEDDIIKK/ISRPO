using System;

namespace PublishingApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int ReleaseYear { get; set; }
        public int Pages { get; set; }
        public int Circulation { get; set; }
        public decimal Price => CalculatePrice();

        private decimal CalculatePrice()
        {
            // Простая логика расчета цены
            decimal basePrice = Pages * 5;
            decimal circulationFactor = 1.0m - (Circulation / 10000.0m);
            return basePrice * Math.Max(0.5m, circulationFactor);
        }
    }
}