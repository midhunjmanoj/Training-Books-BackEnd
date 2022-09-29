using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class WishList
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        
        public WishList( int uid, int bid)
        {
            BookId = bid;
            UserId = uid;
        }
    }
}