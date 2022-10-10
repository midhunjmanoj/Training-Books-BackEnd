using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public interface IBookRepository
    {
        List<Book> GetAllBook();

        List<Book> GetBookByCategory(string catId);
        Book GetBookById(string Bookid);
        Book AddBook(Book book);
        void DeleteBook(string BookId);
        void UpdateBook(Book book);

    }
}
