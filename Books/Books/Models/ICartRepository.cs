using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    internal interface ICartRepository
    {
        List<Book> GetUserCart(string userId);
        void AddBookToCart(string userId, string bookId);
        void DeleteBookFromCart(string BookId, string UserId);
       
    }
}
