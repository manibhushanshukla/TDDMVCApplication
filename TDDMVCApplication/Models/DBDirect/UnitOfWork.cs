using System;

namespace TDDMVCApplication.Models.DBDirect
{
    public class UnitOfWork : IDisposable
    {
        private BookEntities entities = null;

        // This will be called from controller default constructor
        public UnitOfWork()
        {
            entities = new BookEntities();
            BooksRepository = new BooksRepository(entities);
        }

        // This will be created from test project and passed on to the
        // controllers parameterized constructors
        public UnitOfWork(IBooksRepository booksRepo)
        {
            BooksRepository = booksRepo;
        }

        public IBooksRepository BooksRepository
        {
            get;
            private set;
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                entities = null;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        #endregion
    }
}