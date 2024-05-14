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
    public partial class AuthForm : Form
    {
        private string connection = "Server=localhost;Port=5432;Database=LibraryDB;User Id=postgres;Password=qwerty123";
        public AuthForm()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string login = loginStr.Text;
            string password = passStr.Text;
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }
            NpgsqlConnection conn = new NpgsqlConnection(connection);
            try
            {
                conn.Open();
                string query = "SELECT id, role_id FROM users WHERE login = @login AND pass = @password";
                using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    object result = command.ExecuteScalar();
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserInfo.UserId = reader.GetInt32(0);
                            int roleId = reader.GetInt32(1);

                            switch (roleId)
                            {
                                case 1:
                                    MessageBox.Show("Добро пожаловать, Клиент!");
                                    ClientForm clientForm = new ClientForm();
                                    clientForm.ShowDialog();
                                    break;
                                case 2:
                                    MessageBox.Show("Добро пожаловать, Администратор!");
                                    AdminForm adminForm = new AdminForm();
                                    adminForm.ShowDialog();
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Неверный логин или пароль.");
                        }
                    }
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }
    }
}
