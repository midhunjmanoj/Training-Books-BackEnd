using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public interface IOrderRepository
    {
        List<Order> GetOrderByUserId(string uid);
        Order MakeOrder(Order order);
        void DeleteOrder(string oid);
        double TotalPrice(string oid);
        List<Book> ViewOrder(string oid);
    }
}
