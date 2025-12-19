using System;
using System.Windows.Forms;
using System.Collections.Generic;
using PublishingApp.Models;

namespace PublishingApp
{
    public partial class FormOrder : Form
    {
        private DatabaseHelper dbHelper;
        private List<Book> books;
        private List<Office> offices;

        public FormOrder()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadBooks();
            LoadOffices();
        }

        private void LoadBooks()
        {
            try
            {
                // Просто создадим тестовые книги
                books = new List<Book>
        {
            new Book { Id = 1, Title = "Война и мир", AuthorName = "Лев Толстой", ReleaseYear = 1869, Pages = 1225, Circulation = 5000 },
            new Book { Id = 2, Title = "Преступление и наказание", AuthorName = "Федор Достоевский", ReleaseYear = 1866, Pages = 672, Circulation = 3000 },
            new Book { Id = 3, Title = "Евгений Онегин", AuthorName = "Александр Пушкин", ReleaseYear = 1833, Pages = 240, Circulation = 7000 }
        };

                comboBoxBooks.DataSource = books;
                comboBoxBooks.DisplayMember = "Title";
                comboBoxBooks.ValueMember = "Id";

                if (books.Count > 0)
                {
                    comboBoxBooks.SelectedIndex = 0;
                    UpdateBookInfo(books[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки книг: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOffices()
        {
            try
            {
                // Просто создадим тестовые офисы
                offices = new List<Office>
        {
            new Office { Id = 1, Name = "Главный офис", Address = "ул. Центральная, 1", Phone = "+7 (495) 111-11-11" },
            new Office { Id = 2, Name = "Филиал на юге", Address = "ул. Южная, 25", Phone = "+7 (495) 222-22-22" },
            new Office { Id = 3, Name = "Филиал на севере", Address = "ул. Северная, 10", Phone = "+7 (495) 333-33-33" }
        };

                comboBoxOffice.DataSource = offices;
                comboBoxOffice.DisplayMember = "Name";
                comboBoxOffice.ValueMember = "Id";

                if (offices.Count > 0)
                {
                    comboBoxOffice.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки офисов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateBookInfo(Book book)
        {
            if (book != null)
            {
                lblBookTitle.Text = book.Title;
                lblAuthor.Text = book.AuthorName;
                lblYear.Text = book.ReleaseYear.ToString();
                lblPages.Text = book.Pages.ToString();
                lblCirculation.Text = book.Circulation.ToString();

                // Рассчитываем цену (простая формула)
                decimal price = 100 + (book.Pages * 2) + (book.Circulation / 100m);
                lblPrice.Text = $"{price:C}";
            }
        }

        private void comboBoxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBooks.SelectedItem is Book selectedBook)
            {
                UpdateBookInfo(selectedBook);
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Валидация данных
                if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
                {
                    MessageBox.Show("Введите ФИО клиента!", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerName.Focus();
                    return;
                }

                if (comboBoxBooks.SelectedItem == null)
                {
                    MessageBox.Show("Выберите книгу!", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxOffice.SelectedItem == null)
                {
                    MessageBox.Show("Выберите офис получения!", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Создание клиента
                var customer = new Customer
                {
                    Name = txtCustomerName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Phone = txtPhone.Text.Trim()
                };

                // Сохранение клиента в БД
                int customerId = dbHelper.CreateCustomer(customer);

                // Получение выбранной книги и офиса
                var selectedBook = (Book)comboBoxBooks.SelectedItem;
                var selectedOffice = (Office)comboBoxOffice.SelectedItem;

                // Расчет цены
                decimal price = 100 + (selectedBook.Pages * 2) + (selectedBook.Circulation / 100m);

                // Создание заказа
                var order = new Order
                {
                    OrderName = $"Предзаказ: {selectedBook.Title}",
                    BookId = selectedBook.Id,
                    BookTitle = selectedBook.Title,
                    OfficeId = selectedOffice.Id,
                    OfficeName = selectedOffice.Name,
                    CustomerId = customerId,
                    CustomerName = customer.Name,
                    OrderDate = DateTime.Now,
                    Price = price
                };

                // Сохранение заказа в БД
                int orderId = dbHelper.CreateOrder(order);

                // Показать чек
                ShowReceipt(orderId, order);

                // Очистить форму
                ClearForm();

                MessageBox.Show($"Заказ №{orderId} успешно оформлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при оформлении заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowReceipt(int orderId, Order order)
        {
            string receipt = $"=== ЧЕК ПРЕДЗАКАЗА ===\n" +
                            $"Номер заказа: {orderId}\n" +
                            $"Дата: {order.OrderDate:dd.MM.yyyy HH:mm}\n" +
                            $"Клиент: {order.CustomerName}\n" +
                            $"Книга: {order.BookTitle}\n" +
                            $"Офис получения: {order.OfficeName}\n" +
                            $"Цена: {order.Price:C}\n" +
                            $"========================\n" +
                            $"Спасибо за заказ!";

            MessageBox.Show(receipt, "Чек предзаказа",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearForm()
        {
            txtCustomerName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            if (books.Count > 0)
                comboBoxBooks.SelectedIndex = 0;
            if (offices.Count > 0)
                comboBoxOffice.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {

        }
    }
}