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
    public partial class BooksList : Form
    {
        string connectionString = "Server=localhost;Port=5432;Database=LibraryDB;User Id=postgres;Password=qwerty123";
        public BooksList()
        {
            InitializeComponent();
            LoadBooksData();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBook_Click(object sender, EventArgs e)
        {
            using (AddBook addBookForm = new AddBook())
            {
                if (addBookForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string title = addBookForm.Title;
                        int author = addBookForm.SelectedAuthorId;
                        decimal price = addBookForm.Price;
                        int quantity = addBookForm.Quantity;

                        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = @"INSERT INTO books (author_id, title, price, quantity) 
                                    VALUES (@author, 
                                            @title, 
                                            @price, 
                                            @quantity)";
                            NpgsqlCommand command = new NpgsqlCommand(query, connection);
                            command.Parameters.AddWithValue("@author", author);
                            command.Parameters.AddWithValue("@title", title);
                            command.Parameters.AddWithValue("@price", price);
                            command.Parameters.AddWithValue("@quantity", quantity);
                            command.ExecuteNonQuery();
                        }

                        LoadBooksData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при добавлении книги: " + ex.Message);
                    }
                }
            }
        }
        private void LoadBooksData()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"select b.id,
	                                au.author_full_name,
	                                b.title,
	                                b.price,
	                                b.quantity
	                                from books b
	                                join authors au on b.author_id = au.id";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Books");
                    dataGridOrders.DataSource = dataSet.Tables["Books"];
                    dataGridOrders.Columns[0].HeaderText = "Номер книги";
                    dataGridOrders.Columns[1].HeaderText = "Автор";
                    dataGridOrders.Columns[2].HeaderText = "Название";
                    dataGridOrders.Columns[3].HeaderText = "Цена(руб)";
                    dataGridOrders.Columns[4].HeaderText = "Количество";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных из базы данных: " + ex.Message);
            }
        }
    }
}
