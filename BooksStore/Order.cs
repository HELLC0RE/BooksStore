using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksStore
{
    public partial class Order : Form
    {
        private Dictionary<int, string> authorNames = new Dictionary<int, string>();
        string connectionString = "Server=localhost;Port=5432;Database=LibraryDB;User Id=postgres;Password=qwerty123";
        private decimal TotalAmount { get; set; }
        private List<Book> books;
        private Dictionary<Book, int> selectedBooksCount;
        public Order()
        {
            InitializeComponent();
        }
        public void UpdateBooksList(List<Book> updatedBooks, Dictionary<Book, int> updatedSelectedBooksCount)
        {
            this.books = updatedBooks;
            this.selectedBooksCount = updatedSelectedBooksCount;
            UpdateLayoutPanel();
        }
        public void AddBooksToLayoutPanel(List<Book> books, Dictionary<Book, int> selectedBooksCount)
        {
            this.books = books;
            this.selectedBooksCount = selectedBooksCount;
            foreach (var book in books)
            {
                Panel bookPanel = new Panel
                {
                    Height = 90,
                    Width = flowLayoutPanelOrder.Width - 5,
                    BorderStyle = BorderStyle.FixedSingle,

                };

                PictureBox pictureBox = new PictureBox
                {
                    Image = Properties.Resources.book_icon,
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Location = new Point(20, 5),
                    Width = 85,
                    Height = 80,
                };
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                Label titleLabel = new Label
                {
                    Text = $"Название: \n{book.Title}",
                    AutoSize = false,
                    TextAlign = ContentAlignment.TopLeft,
                    Location = new Point(120, 20),
                    Width = 150,
                    Height = 150,
                    Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 10)
                };
                titleLabel.MouseClick += HandleRightClickOnBook;
                Label costLabel = new Label
                {
                    Text = $"Стоимость: \n {book.Price:C}",
                    Location = new Point(650, 20),
                    Width = 100,
                    Height = 50,
                    Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                };

                string authorName = authorNames.ContainsKey(book.Author_Id) ? authorNames[book.Author_Id] : "Неизвестный автор";
                Label authorLabel = new Label
                {
                    Text = $"Автор:\n{authorName}",
                    Location = new Point(400, 20),
                    Width = 300,
                    Height = 50,
                    Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                };

                Label quantityLabel = new Label
                {
                    Text = $"Количество: \n {(selectedBooksCount.ContainsKey(book) ? selectedBooksCount[book] : 0)}",
                    Location = new Point(300, 20),
                    Width = 200,
                    Height = 50,
                    Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                };



                bookPanel.Controls.Add(pictureBox);
                bookPanel.Controls.Add(titleLabel);
                bookPanel.Controls.Add(costLabel);
                bookPanel.Controls.Add(authorLabel);
                bookPanel.Controls.Add(quantityLabel);

                flowLayoutPanelOrder.Controls.Add(bookPanel);
            }
            TotalAmount = CalculateTotalAmount(books, selectedBooksCount);
            totalAmountLabel.Text = $"Общая сумма заказа: {TotalAmount:C}";
        }

        private decimal CalculateTotalAmount(List<Book> books, Dictionary<Book, int> selectedBooksCount)
        {
            decimal totalAmount = 0;

            foreach (var kvp in selectedBooksCount)
            {
                Book book = kvp.Key;
                int quantity = kvp.Value;
                decimal bookPrice = book.Price * quantity;
                totalAmount += bookPrice;
            }
            return totalAmount;
        }
        private void UpdateLayoutPanel()
        {
            flowLayoutPanelOrder.Controls.Clear();
            AddBooksToLayoutPanel(books, selectedBooksCount);
        }
        private void HandleRightClickOnBook(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Label clickedLabel = (Label)sender;
                Book clickedBook = books.FirstOrDefault(p => p.Title == clickedLabel.Text.Split('\n')[1].Trim());

                if (clickedBook != null)
                {
                    ContextMenuStrip contextMenu = new ContextMenuStrip();

                    ToolStripMenuItem removeFromOrderMenuItem = new ToolStripMenuItem("Удалить из заказа");
                    removeFromOrderMenuItem.Click += (menuItemSender, menuItemEventArgs) =>
                    {
                        if (selectedBooksCount.ContainsKey(clickedBook))
                        {
                            if (selectedBooksCount[clickedBook] == 1)
                            {
                                books.Remove(clickedBook);
                                selectedBooksCount.Remove(clickedBook);
                            }
                            else
                            {
                                selectedBooksCount[clickedBook]--;
                            }
                            UpdateLayoutPanel();
                        }
                    };

                    contextMenu.Items.Add(removeFromOrderMenuItem);

                    contextMenu.Show(clickedLabel, e.Location);
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.MinValue;
            try
            {
                if (addressTextBox == null)
                {
                    MessageBox.Show("Напишите адрес для доставки");
                    return;
                }
                string selectedAddress = addressTextBox.Text;

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    Dictionary<Book, int> selectedBooksCount = new Dictionary<Book, int>();
                    foreach (var book in books)
                    {
                        int quantity = selectedBooksCount.ContainsKey(book) ? selectedBooksCount[book] : 0;
                        selectedBooksCount[book] = quantity + 1;
                    }

                    foreach (var entry in selectedBooksCount)
                    {
                        Book book = entry.Key;
                        int quantityOrdered = entry.Value;

                        int availableQuantity = book.Quantity;
                        if (quantityOrdered > availableQuantity)
                        {
                            MessageBox.Show($"Недостаточное количество книг \"{book.Title}\" на складе.");
                            return;
                        }
                    }

                    decimal totalAmount = CalculateTotalAmount(books, selectedBooksCount);
                    string query = "INSERT INTO orders (user_id, status_id, order_date, total_amount, delivery_address) " +
                        "VALUES (@user_id, @status_id, @order_date, @total_amount, @delivery_address)";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("user_id", UserInfo.UserId);
                    command.Parameters.AddWithValue("status_id", 1);
                    command.Parameters.AddWithValue("order_date", DateTime.Now.Date);
                    command.Parameters.AddWithValue("total_amount", totalAmount);
                    command.Parameters.AddWithValue("delivery_address", selectedAddress);
                    command.ExecuteNonQuery();

                    foreach (var entry in selectedBooksCount)
                    {
                        Book book = entry.Key;
                        int quantityOrdered = entry.Value;
                        int updatedQuantity = book.Quantity - quantityOrdered;

                        query = "UPDATE books SET quantity = @quantity WHERE id = @book_id";
                        var commandd = new NpgsqlCommand(query, connection);
                        commandd.Parameters.AddWithValue("@quantity", updatedQuantity);
                        commandd.Parameters.AddWithValue("@book_id", book.Id);
                        await commandd.ExecuteNonQueryAsync();
                    }
                    MessageBox.Show("Заказ успешно оформлен!");

                    UpdateBooksList(books, selectedBooksCount);
                    books.Clear();
                    selectedBooksCount.Clear();
                    UpdateLayoutPanel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании заказа: " + ex.Message);
            }
        }
        
        public void LoadAuthorNames()
        {
            authorNames.Clear();

            string connectionString = "Server=localhost;Port=5432;Database=LibraryDB;User Id=postgres;Password=qwerty123";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT id, author_full_name FROM authors";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int authorId = reader.GetInt32(0);
                            string authorFullName = reader.GetString(1);
                            authorNames.Add(authorId, authorFullName);
                        }
                    }
                }
            }
        }
    }
}
