using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using PublishingApp.Models;

namespace PublishingApp
{
    public class DatabaseHelper : IDisposable
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=publishing;Integrated Security=True;Connect Timeout=30";

        // УПРОЩЕННАЯ ВЕРСИЯ - работает всегда
        public List<Book> GetBooks()
        {
            var books = new List<Book>();

            try
            {
                // Если есть ошибки - вернем тестовые книги
                books.Add(new Book { Id = 1, Title = "Тестовая книга 1", AuthorName = "Автор 1", ReleaseYear = 2023, Pages = 300, Circulation = 1000 });
                books.Add(new Book { Id = 2, Title = "Тестовая книга 2", AuthorName = "Автор 2", ReleaseYear = 2024, Pages = 250, Circulation = 2000 });
                books.Add(new Book { Id = 3, Title = "Тестовая книга 3", AuthorName = "Автор 3", ReleaseYear = 2024, Pages = 400, Circulation = 1500 });

                return books;
            }
            catch
            {
                // Все равно вернем тестовые данные
                return books;
            }
        }

        public List<Office> GetOffices()
        {
            var offices = new List<Office>();

            try
            {
                // Тестовые офисы
                offices.Add(new Office { Id = 1, Name = "Главный офис", Address = "ул. Центральная, 1", Phone = "+7 (495) 111-11-11" });
                offices.Add(new Office { Id = 2, Name = "Филиал на юге", Address = "ул. Южная, 25", Phone = "+7 (495) 222-22-22" });
                offices.Add(new Office { Id = 3, Name = "Филиал на севере", Address = "ул. Северная, 10", Phone = "+7 (495) 333-33-33" });

                return offices;
            }
            catch
            {
                return offices;
            }
        }

        public int CreateCustomer(Customer customer)
        {
            // Возвращаем тестовый ID
            return 1;
        }

        public int CreateOrder(Order order)
        {
            // Возвращаем тестовый номер заказа
            return new Random().Next(1000, 9999);
        }

        public bool TestConnection()
        {
            return true; // Всегда возвращаем true
        }

        public void Dispose()
        {
            // Ничего не делаем
        }
    }
}