using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public interface IWishlistRepository
    {
        List<Book> GetWishlist(string userId);
        void AddToWishlist(string userId,string bookId);
        void DeleteFromWishlist(string userId,string bookId);
        
    }
}
