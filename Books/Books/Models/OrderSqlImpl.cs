using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Books.Models
{
    public class OrderSqlImpl : IOrderRepository
    {
        SqlConnection conn;
        SqlCommand comm;
        public OrderSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();

        }

        public void DeleteOrder(string oid)
        {
            comm.CommandText = "Delete from [order] where OrderId ='" + oid + "'";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

       
        public List<Order> GetOrderByUserId(string uid)
        {
            List<Order> list = new List<Order>();
            comm.CommandText = "Select * from [order] where UserId ='" + uid + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string orderid = reader["OrderId"].ToString();
                string userid = reader["UserId"].ToString();
                int NoOfBooks=Convert.ToInt32(reader["NoOfBooks"]);
                double price = Convert.ToDouble(reader["Price"]);
                string CouponCode = reader["CouponCode"].ToString();
                list.Add(new Order(orderid, userid, NoOfBooks, price, CouponCode));

            }
            conn.Close();
            return list;
        }

        public Order MakeOrder(Order order)
        {
            comm.CommandText = "insert into [Order] values('" + order.OrderId + "','" + order.UserId + "'," + order.NoOfBooks + "," + order.Price + ",'" + order.CouponCode + "')";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            if (rows > 0)
            {
                return order;
            }
            else
            {
                return null;
            }
        }

        public double TotalPrice(string oid)
        {
            comm.CommandText = "select sum(Book.Price) from OrderedBookList inner join Book on OrderedBookList.BookId=Book.BookId where OrderedBookList.Orderid='" + oid+"'";
            comm.Connection = conn;
            conn.Open();
            double totalprice = (double)comm.ExecuteScalar();
            return totalprice;
        }

        public List<Book> ViewOrder(string oid)
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select Book.BookId,Book.CategoryId,Book.Title,Book.Isbn,Book.Year,Book.Price,Book.Description,Book.Position,Book.Status,Book.Image from Book join OrderedBookList on Book.BookId=OrderedBookList.BookId where OrderedBookList.OrderId='" + oid+"'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string bookid = (reader["BookId"]).ToString();
                string catid = (reader["CategoryId"]).ToString();
                string title = reader["title"].ToString();
                int ISBN = Convert.ToInt32(reader["Isbn"]);
                int year = Convert.ToInt32(reader["Year"]);
                int price = Convert.ToInt32(reader["Price"]);
                string Description = reader["Description"].ToString();
                string Position = reader["Position"].ToString();
                string Status = reader["Status"].ToString();
                string Image = reader["Image"].ToString();
                list.Add(new Book(bookid, catid, title, ISBN, year, price, Description, Position, Status, Image));

            }
            conn.Close();
            return list;
        }
    }
}