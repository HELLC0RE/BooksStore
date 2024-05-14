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
    public partial class AddBook : Form
    {
        string connectionString = "Server=localhost;Port=5432;Database=LibraryDB;User Id=postgres;Password=qwerty123";
        public AddBook()
        {
            InitializeComponent();
            LoadAuthors();
        }
        public string Title
        {
            get { return titleBox.Text; }
        }

        public decimal Price
        {
            get { return decimal.Parse(priceBox.Text); }
        }
        public int SelectedAuthorId
        {
            get
            {
                if (authorsBox.SelectedItem != null)
                {
                    return ((AuthorItem)authorsBox.SelectedItem).Id;
                }
                return -1; 
            }
        }
        public int Quantity
        {
            get { return int.Parse(quantityBox.Text); }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void LoadAuthors()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, author_full_name FROM authors";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int authorId = reader.GetInt32(0);
                        string authorName = reader.GetString(1);
                        authorsBox.Items.Add(new AuthorItem(authorId, authorName));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке авторов: " + ex.Message);
            }
        }
        public class AuthorItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public AuthorItem(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
