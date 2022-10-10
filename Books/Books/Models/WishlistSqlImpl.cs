using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Books.Models
{
    public class WishlistSqlImpl : IWishlistRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public WishlistSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public void AddToWishlist(string userId, string bookId)
        {
            comm.CommandText = "insert into Wishlist values ('" + userId + "','" + bookId + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteFromWishlist(string userId, string bookId)
        {
            comm.CommandText = "Delete from Wishlist where BookId = '" + bookId + "' and UserId ='" + userId + "';";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Book> GetWishlist(string userId)
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from book where BookId in (select BookID from Wishlist where UserId = '" + userId + "');";
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
    }
}