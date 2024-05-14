using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BooksStore
{
    public partial class ClientForm : Form
    {
        private Dictionary<int, string> authorNames = new Dictionary<int, string>();
        private const int itemsPerPage = 5;
        private int currentPage = 1;
        private int offset;
        private int limit;
        private int totalPages;
        private Dictionary<Book, int> selectedBooksCount = new Dictionary<Book, int>();
        private List<Book> selectedBooks = new List<Book>();
        public ClientForm()
        {
            InitializeComponent();
            searchText.Text = "Введите для поиска";
            DisplayPage(currentPage, null, null);
            showOrder.Visible = false;
            sortBox.DrawMode = DrawMode.OwnerDrawFixed;
            sortBox.ItemHeight = 30;
        }
        private void DisplayBook(Book book)
        {
            Panel bookPanel = new Panel
            {
                Height = 90,
                Width = flowLayoutPanelProducts.Width - 5,
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
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem addItemToOrderMenuItem = new ToolStripMenuItem("Добавить в заказ");
            addItemToOrderMenuItem.Click += (sender, e) =>
            {
                if (!selectedBooks.Contains(book))
                {
                    selectedBooks.Add(book);
                }

                if (selectedBooksCount.ContainsKey(book))
                {
                    selectedBooksCount[book]++;
                }
                else
                {
                    selectedBooksCount.Add(book, 1);
                }

                showOrder.Visible = true;
            };
            contextMenu.Items.Add(addItemToOrderMenuItem);

            titleLabel.ContextMenuStrip = contextMenu;

            titleLabel.MouseClick += (sender, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    contextMenu.Show(titleLabel, e.Location);
                }
            };
            Label costLabel = new Label
            {
                Text = $"Стоимость: \n{book.Price:C}",
                Location = new Point(650, 20),
                Width = 100,
                Height = 50,
                Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
            };

            Label quantityLabel = new Label
            {
                Text = $"Количество:\n{book.Quantity}",
                Location = new Point(275, 20),
                Width = 120,
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
            bookPanel.Controls.Add(pictureBox);
            bookPanel.Controls.Add(titleLabel);
            bookPanel.Controls.Add(costLabel);
            bookPanel.Controls.Add(quantityLabel);
            bookPanel.Controls.Add(authorLabel);

            flowLayoutPanelProducts.Controls.Add(bookPanel);
        }

        private void DisplayPagination(int count)
        {
            totalPages = (int)Math.Ceiling((double)count / itemsPerPage);

            flowLayoutPanelPagination.RightToLeft = RightToLeft.Yes;

            AddPageButton("<", currentPage + 1);

            for (int i = totalPages; i != 0; i--)
            {
                Label pageButton = new Label
                {
                    Text = i.ToString(),
                    Width = 20,
                    Height = 20,
                    Margin = new Padding(5),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand
                };

                if (i == currentPage)
                {
                    pageButton.Font = new System.Drawing.Font(pageButton.Font, FontStyle.Bold | FontStyle.Underline);
                }

                pageButton.Click += (sender, e) =>
                {
                    currentPage = int.Parse(((Label)sender).Text);
                    DisplayPage(currentPage, searchText.Text, sortBox.Text);
                };

                flowLayoutPanelPagination.Controls.Add(pageButton);
            }

            AddPageButton(">", currentPage - 1);
        }

        private void AddPageButton(string buttonText, int targetPage)
        {
            Label pageButton = new Label
            {
                Text = buttonText,
                Width = 15,
                Height = 15,
                Margin = new Padding(5),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            pageButton.Click += (sender, e) =>
            {
                if (targetPage > 0 && targetPage <= totalPages)
                {
                    currentPage = targetPage;
                    DisplayPage(currentPage, searchText.Text, sortBox.Text);
                }
            };

            flowLayoutPanelPagination.Controls.Add(pageButton);
        }
        private void DisplayPage(int page, string text, string sorter)
        {
            flowLayoutPanelProducts.Controls.Clear();
            flowLayoutPanelPagination.Controls.Clear();

            offset = (page - 1) * itemsPerPage;
            limit = itemsPerPage;
            var filteredProducts = GetAllBooks(); ;

            if (!string.IsNullOrEmpty(text) && text != "Введите для поиска")
            {
                filteredProducts = filteredProducts
                    .Where(p => p.Title.Contains(text))
                .ToList(); 
            }

            if (!string.IsNullOrEmpty(sorter) && sorter != "Сортировка")
            {
                switch (sorter)
                {
                    case "По наименованию (по возрастанию)":
                        filteredProducts = filteredProducts.OrderBy(p => p.Title).ToList();
                        break;
                    case "По наименованию (по убыванию)":
                        filteredProducts = filteredProducts.OrderByDescending(p => p.Title).ToList();
                        break;
                    case "По стоимости (по возрастанию)":
                        filteredProducts = filteredProducts.OrderBy(p => p.Price).ToList();
                        break;
                    case "По стоимости (по убыванию)":
                        filteredProducts = filteredProducts.OrderByDescending(p => p.Price).ToList();
                        break;
                    default:
                        break;
                }
            }            
            int resultCount = filteredProducts.Count;
            filteredProducts = filteredProducts.Skip(offset).Take(limit).ToList();

            for (int i = 0; i < filteredProducts.Count; i++)
            {
                DisplayBook(filteredProducts[i]);
            }

            DisplayPagination(resultCount);
        }
        public static List<Book> GetAllBooks()
        {
            string connectionString = "Server=localhost;Port=5432;Database=LibraryDB;User Id=postgres;Password=qwerty123";
            List<Book> allProducts = new List<Book>();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM books";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book
                            {
                                Author_Id = reader.GetInt32(1),
                                Title = reader.GetString(2),
                                Price = reader.GetDecimal(3),
                                Quantity = reader.GetInt32(4),
                            };
                            allProducts.Add(book);
                        }
                    }
                }
            }

            return allProducts;
        }
        private async Task LoadAuthorNames()
        {
            authorNames.Clear();

            string connectionString = "Server=localhost;Port=5432;Database=LibraryDB;User Id=postgres;Password=qwerty123";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string sql = "SELECT id, author_full_name FROM authors";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int authorId = reader.GetInt32(0);
                            string authorFullName = reader.GetString(1);
                            authorNames.Add(authorId, authorFullName);
                        }
                    }
                }
            }
        }
        private async void ClientForm_Load(object sender, EventArgs e)
        {
            await LoadAuthorNames();
            DisplayPage(currentPage, null, null);
        }

        private void showOrder_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.LoadAuthorNames();
            order.AddBooksToLayoutPanel(selectedBooks, selectedBooksCount);
            order.ShowDialog();
        }
        private void SortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            DisplayPage(currentPage, searchText.Text, sortBox.Text);
        }
        private void SortBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            using (SolidBrush brush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(sortBox.Items[e.Index].ToString(), e.Font, brush, e.Bounds);
            }
            e.DrawFocusRectangle();
        }
        private void SearchText_Enter(object sender, EventArgs e)
        {
            if (searchText.Text.Equals("Введите для поиска"))
            {
                searchText.Clear();
                searchText.ForeColor = Color.Black;
            }
        }
        private void SearchText_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchText.Text))
            {
                searchText.Text = "Введите для поиска";
                searchText.ForeColor = Color.Gray;
            }
        }

        private void SearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            currentPage = 1;
            DisplayPage(currentPage, searchText.Text, sortBox.Text);
        }
    }
}