using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore
{
    public class Book
    {
        public int Id { get; set; }
        public int Author_Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Book() { }

        public Book(int id, int author_id, string title, decimal price, int quantity)
        {
            Id = id;
            Author_Id = author_id;
            Title = title;
            Price = price;
            Quantity = quantity;
        }
    }
}
