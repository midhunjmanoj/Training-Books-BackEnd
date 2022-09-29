using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Cart
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public Cart()
        {

        }
        public Cart(int bid, int uid)
        {
            BookId = bid;
            UserId = uid;
        }
    }
}