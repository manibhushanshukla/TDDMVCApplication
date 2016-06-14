using System;
using System.Collections.Generic;
using System.Linq;
using TDDMVCApplication.DBService;

namespace TDDMVCApplication.Models.Service
{
    public class ServiceBooksRepository : IServiceBooksRepository
    {
        DBService.ServiceLibraryClient serviceClient = null;

        public ServiceBooksRepository(DBService.ServiceLibraryClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        public void AddBook(Book book)
        {
            serviceClient.AddBook(book);
        }

        public void DeleteBook(Book book)
        {
            serviceClient.DeleteBook(book);
        }

        public Book Details(int id)
        {
           return serviceClient.Details(id);
        }

        public List<Book> GetAllBooks()
        {
           return serviceClient.GetAllBooks();
        }

        public void UpdateBook(Book book)
        {
            serviceClient.UpdateBook(book);
        }
    }
}