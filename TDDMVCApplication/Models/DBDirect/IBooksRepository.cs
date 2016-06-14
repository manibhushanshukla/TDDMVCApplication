using System.Collections.Generic;
using TDDMVCApplication.Models.DBDirect;

namespace TDDMVCApplication.Models.DBDirect
{
    public interface IBooksRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
        void Save();
    }
}
