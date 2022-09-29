using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public int NoOfBooks { get; set; }
        public double Price { get; set; }
        public string CouponCode { get; set; }
        public Order()
        {

        }
        public Order(string id, string uid, int nob, double price, string cc)
        {
            OrderId = id;
            UserId = uid;
            NoOfBooks = nob;
            Price = price;
            CouponCode = cc;
        }
    }
}