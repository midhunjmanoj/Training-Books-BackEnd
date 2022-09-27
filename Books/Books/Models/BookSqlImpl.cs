using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Books.Models
{
    public class BookSqlImpl : IBookRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public BookSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Book AddBook(Book book)
        {
            comm.CommandText = "insert into Book values ('" + book.BookId + "','" +
                book.CategoryId + "','" +
                book.Title + "'," +
                book.Isbn + "," +
                book.Year + "," +
                book.Price + ",'" +
                book.Description + "','" +
                book.Position + "','" +
                book.Status + "','" +
                book.Image + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return book;
            }
            else
            {
                return null;
            }
        }

        public void DeleteBook(string BookId)
        {
            comm.CommandText = "Delete from book where BookId = '" + BookId+"'";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Book> GetAllBook()
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from book";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string bookId = reader["BookId"].ToString();
                string categoryId = reader["CategoryId"].ToString();
                string title = reader["Title"].ToString();
                int isbn = Convert.ToInt32(reader["Isbn"]);
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string description = reader["Description"].ToString();
                string position = reader["Position"].ToString();
                string status = reader["Status"].ToString();
                string image = reader["Image"].ToString();

                list.Add(new Book(bookId, categoryId, title, isbn, year, price, description, position, status, image));
            }
            conn.Close();
            return list;
        }

        public Book GetBookById(string BookId)
        {
            comm.CommandText = "select * from Book where BookId = '" + BookId+"'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string bookId = reader["BookId"].ToString();
                string categoryId = reader["CategoryId"].ToString();
                string title = reader["Title"].ToString();
                int isbn = Convert.ToInt32(reader["Isbn"]);
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["price"]);
                string description = reader["Description"].ToString();
                string position = reader["Position"].ToString();
                string status = reader["Status"].ToString();
                string image = reader["Image"].ToString();

                Book emp = new Book(bookId, categoryId, title, isbn, year, price, description, position, status, image);
                return emp;
            }
            conn.Close();
            return null;
        }

        public void UpdateBook(Book book)
        {
            comm.CommandText = "update book set BookId='"+book.BookId+ "',CategoryId='" + book.CategoryId 
                + "',Title='" + book.Title + "',Isbn=" + book.Isbn + ",Year=" + book.Year + ",Price=" + book.Price +
                ",Description='" + book.Description + "',Position = '" + book.Position +
                "', Status ='" + book.Status + "',Image='" + book.Image + "' where BookId = '"+book.BookId+"';";
            comm.Connection = conn;
            conn.Open();
            int raw = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}