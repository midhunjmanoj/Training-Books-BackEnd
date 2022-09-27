using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Books.Models
{
    public class CategorySqlImpl : ICategoryRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public CategorySqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Category AddCategory(Category category)
        {
            comm.CommandText = "Insert into Category values( '" +
                 category.CategoryId + "','" +
                 category.CategoryName + "','" +
                 category.Description + "','" +
                 category.Image + "','" +
                 category.Status + "','" +
                 category.Position + "','" +
                 category.CreatedAt + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if(row > 0)
            {
                return category;
            }
            {
                return null;
            }
        }


        public void DeleteCategory(string id)
        {
            comm.CommandText = "Delete from Category where CategoryId = '" + id + "'";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Category> GetAllCategories()
        {
            List<Category> list = new List<Category>();
            comm.CommandText = "select * from Category";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string categoryId = reader["CategoryId"].ToString();
                string categoryName = reader["CategoryName"].ToString();
                string description = reader["Description"].ToString();
                string image = reader["Image"].ToString();
                string status = reader["Status"].ToString();
                string position = reader["Position"].ToString();
                string createdAt = reader["CreatedAt"].ToString();

                list.Add(new Category(categoryId, categoryName, description, image, status, position, createdAt));
            }
            conn.Close();
            return list;
        }

        public Category GetCategoryById(string id)
        {
            comm.CommandText = "Select * from Category where CategoryId = '" + id + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                string categoryId = reader["CategoryId"].ToString();
                string categoryName = reader["CategoryName"].ToString();
                string description = reader["Description"].ToString();
                string image = reader["Image"].ToString();
                string status = reader["Status"].ToString();
                string position = reader["Position"].ToString();
                string createdAt = reader["CreatedAt"].ToString();

                Category cat = new Category(categoryId, categoryName, description, image, status, position, createdAt);
                return cat;
            }
            conn.Close();
            return null;
        }
        public void UpdateCategory(Category category)
        {
            comm.CommandText = "Update Category set CategoryId='" + category.CategoryId + "',CatergoryName='" + category.CategoryName +
                "', Description = '" + category.Description +
                "',image = '" + category.Image + "', status='" + category.Status +
                "', position='" + category.Position + "',createdAt='" + category.CreatedAt + "' where CategoryId = '"+category.CategoryId+
                "';";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}