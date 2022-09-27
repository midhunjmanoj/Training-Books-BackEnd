using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Book
    {
        public string BookId { get; set; }
        public string CategoryId { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public int Year { get; set; }
        public int Isbn { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }

        public Book(string bookId, string categoryId, string title, int isbn, int year, int price, string description, string position, string status, string image)
        {
            BookId = bookId;
            CategoryId = categoryId;
            Title = title;
            Isbn = isbn;
            Year = year;
            Price = Price;
            Description = description;
            Position = position;
            Status = status;
            Image = image;
        }

    }
}