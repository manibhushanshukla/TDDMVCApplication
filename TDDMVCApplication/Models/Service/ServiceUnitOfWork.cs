using System;

namespace TDDMVCApplication.Models.Service
{
    public class ServiceUnitOfWork : IDisposable
    {
        DBService.ServiceLibraryClient serviceClient = null;

        // This will be called from controller default constructor
        public ServiceUnitOfWork()
        {
            serviceClient = new DBService.ServiceLibraryClient();
            ServiceBooksRepository = new ServiceBooksRepository(serviceClient);
        }

        // This will be created from test project and passed on to the
        // controllers parameterized constructors
        public ServiceUnitOfWork(IServiceBooksRepository booksRepo)
        {
            ServiceBooksRepository = booksRepo;
        }

        public IServiceBooksRepository ServiceBooksRepository
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
                serviceClient = null;
            }
        }

        ~ServiceUnitOfWork()
        {
            Dispose(false);
        }

        #endregion
    }
}