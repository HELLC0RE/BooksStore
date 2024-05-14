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
    public partial class Registration : Form
    {
        string connectionString = "Server=localhost;Port=5432;Database=LibraryDB;User Id=postgres;Password=qwerty123";
        public Registration()
        {
            InitializeComponent();
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            string login = loginStr.Text;
            string password = passStr.Text;
            string name = nameTextBox.Text;
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите логин, пароль и имя.");
                return;
            }
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                if (!IsLoginUnique(login, conn))
                {
                    MessageBox.Show("Логин уже занят. Пожалуйста, выберите другой логин.");
                    return;
                }

                if (IsPasswordValid(password))
                {
                    Bitmap captchaImage = new Bitmap(200, 50);
                    string captchaText = GenerateCaptcha(); 
                    using (Graphics g = Graphics.FromImage(captchaImage))
                    {
                       
                        DrawCaptcha(g, captchaText);
                    }                  
                    CaptchaForm captchaForm = new CaptchaForm(captchaImage, captchaText); 
                    captchaForm.ShowDialog();
         
                    if (captchaForm.DialogResult == DialogResult.OK)
                    {
                        string query = "INSERT INTO users (role_id, login, pass, name) " +
                        "VALUES (@role_id, @login, @pass, @name)";
                        NpgsqlCommand command = new NpgsqlCommand(query, conn);                     
                        command.Parameters.AddWithValue("role_id", 1);
                        command.Parameters.AddWithValue("login", login);
                        command.Parameters.AddWithValue("pass", password);
                        command.Parameters.AddWithValue("name", name);
                        command.ExecuteNonQuery();
                        ClientForm client = new ClientForm();
                        client.ShowDialog();
                    }              
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public bool IsPasswordValid(string password)
        {
            if (password.Length < 5)
            {
                return false;
            }

            int digitCount = password.Count(char.IsDigit);

            if (!password.Any(c => "@#%)(.<".Contains(c)))
            {
                return false;
            }

            return true;
        }
        public bool IsLoginUnique(string login, NpgsqlConnection connection)
        {
            string query = "SELECT * FROM users WHERE login = @login";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@login", login);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count == 0;
            }
        }
        private void DrawCaptcha(Graphics g, string captchaText)
        {
            Font font = new Font("Arial", 16);
            Brush brush = Brushes.Black;
            g.DrawString(captchaText, font, brush, new PointF(10, 10));
            Pen pen = new Pen(Color.Black, 2);
            Random rand = new Random();
            g.DrawLine(pen, new Point(rand.Next(0, 50), rand.Next(0, 25)), new Point(rand.Next(50, 100), rand.Next(0, 50)));
        }

        private string GenerateCaptcha()
        {
            Random rand = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
    }   
}
