using System.Collections.Generic;
using TDDMVCApplication.DBService;

namespace TDDMVCApplication.Models.Service
{
    public interface IServiceBooksRepository
    {        
        List<Book> GetAllBooks();
        Book Details(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
