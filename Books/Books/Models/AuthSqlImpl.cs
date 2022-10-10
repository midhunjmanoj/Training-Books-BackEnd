using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Books.Models
{
    public class AuthSqlImpl : IAuthRepository 
    {
        SqlCommand comm;
        SqlConnection conn;

        public AuthSqlImpl(){
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
    
        public Auth RegisterUser(Auth auth)
        {
            comm.CommandText = "Insert into users values('" +auth.Email +"','"+auth.Password+"','"+auth.Name+"')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return auth;
            }
            else
            {
                return null;
            }
        }

        public Auth ValidateUser(string user,string passwd)
        {
            comm.CommandText = "Select * from users where Email='" + user + "' and Password = '" +passwd + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            
            while (reader.Read())
            {
                string email = reader["Email"].ToString();
                string pwd = reader["Password"].ToString();
                string name = reader["Name"].ToString();

                Auth admin = new Auth(email, pwd,name);
                return admin;
            }
            conn.Close();
            return null;
        }
    }
}