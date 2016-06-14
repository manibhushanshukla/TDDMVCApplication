using System;
using System.Collections.Generic;
using System.Linq;

namespace TDDMVCApplication.Models.DBDirect
{
    public class BooksRepository : IBooksRepository
    {
        BookEntities entities = null;

        public BooksRepository(BookEntities entities)
        {
            this.entities = entities;
        }

        public List<Book> GetAllBooks()
        {
            return entities.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return entities.Books.SingleOrDefault(book => book.ID == id);
        }

        public void AddBook(Book book)
        {            
            entities.Books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            entities.Books.Attach(book);
            entities.Entry(book).State = System.Data.Entity.EntityState.Modified;
        }

        public void DeleteBook(Book book)
        {
            entities.Books.Remove(book);
        }

        public void Save()
        {
            try
            {
                entities.SaveChanges();
            }
            catch (Exception ex) { }
        }
    }
}