using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Auth
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public Auth(string email, string password,string name)
        {
            Email = email;
            Password = password;
            Name = name;
        }
 
    }
}