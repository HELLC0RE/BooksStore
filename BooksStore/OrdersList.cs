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
    public partial class OrdersList : Form
    {
        string connectionString = "Server=localhost;Port=5432;Database=LibraryDB;User Id=postgres;Password=qwerty123";
        public OrdersList()
        {
            InitializeComponent();
            LoadOrdersData();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadOrdersData()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT
                                    o.id,
                                     u.name,
                                s.status_title,
                                  o.order_date,
                                o.total_amount,
                                     o.comment,
                            o.delivery_address 
                                 from orders o 
          join status s on o.status_id = s.id
        join users u on o.user_id = u.id";
                    
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Orders");
                    dataGridOrders.DataSource = dataSet.Tables["Orders"];
                    dataGridOrders.Columns[0].HeaderText = "Номер заказа";
                    dataGridOrders.Columns[1].HeaderText = "Заказчик";
                    dataGridOrders.Columns[2].HeaderText = "Статус заказа";
                    dataGridOrders.Columns[3].HeaderText = "Дата создания";
                    dataGridOrders.Columns[4].HeaderText = "Общая сумма (руб)";
                    dataGridOrders.Columns[5].HeaderText = "Комментарий";
                    dataGridOrders.Columns[6].HeaderText = "Адрес доставки";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных из базы данных: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadOrdersData();
            }
            else
            {
                try
                {
                    string query = @"SELECT
                                o.id AS Номер_заказа,
                                u.name AS Заказчик,
                                s.status_title AS Статус_заказа,
                                o.order_date AS Дата_создания,
                                o.total_amount AS Общая_сумма,
                                o.comment AS Комментарий,
                                o.delivery_address AS Адрес_доставки
                              FROM orders o 
                              JOIN status s ON o.status_id = s.id
                              JOIN users u ON o.user_id = u.id
                              WHERE LOWER(u.name) LIKE LOWER(@searchText)
                                    OR LOWER(s.status_title) LIKE LOWER(@searchText)
                                    OR LOWER(o.order_date::text) LIKE LOWER(@searchText)";

                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        connection.Open();
                        NpgsqlCommand command = new NpgsqlCommand(query, connection);
                        command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridOrders.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных из базы данных: " + ex.Message);
                }
            }
        }

        private void cancelOrder_Click(object sender, EventArgs e)
        {
            UpdateOrderStatus(3);
        }

        private void acceptOrder_Click(object sender, EventArgs e)
        {
            UpdateOrderStatus(2);
        }
        private void UpdateOrderStatus(int statusId)
        {
            
            int orderId = (int)dataGridOrders.CurrentRow.Cells[0].Value;

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE orders SET status_id = @statusId WHERE id = @orderId";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@statusId", statusId);
                    command.Parameters.AddWithValue("@orderId", orderId);
                    command.ExecuteNonQuery();
                }

                LoadOrdersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении статуса заказа: " + ex.Message);
            }

            if (statusId == 3)
            {
                string comment = Microsoft.VisualBasic.Interaction.InputBox("Введите комментарий для отклонения заказа:", "Комментарий", "");

                if (!string.IsNullOrEmpty(comment))
                {
                    try
                    {
                        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                        {
                            connection.Open();
                            string updateCommentQuery = "UPDATE orders SET comment = @comment WHERE id = @orderId";
                            NpgsqlCommand updateCommentCommand = new NpgsqlCommand(updateCommentQuery, connection);
                            updateCommentCommand.Parameters.AddWithValue("@comment", comment);
                            updateCommentCommand.Parameters.AddWithValue("@orderId", orderId);
                            updateCommentCommand.ExecuteNonQuery();
                        }
                        LoadOrdersData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при обновлении комментария: " + ex.Message);
                    }
                }
            }
        }
    }
}
