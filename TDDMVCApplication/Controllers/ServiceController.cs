using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDDMVCApplication.DBService;
using TDDMVCApplication.Models.Service;

namespace TDDMVCApplication.Controllers
{
    public class ServiceController : Controller
    {

        private ServiceUnitOfWork serviceUnitOfWork = null;

        public ServiceController()
            : this(new ServiceUnitOfWork())
        {

        }

        public ServiceController(ServiceUnitOfWork uow)
        {
            this.serviceUnitOfWork = uow;
        }

        public ActionResult Index()
        {
            List<Book> books = serviceUnitOfWork.ServiceBooksRepository.GetAllBooks();
            return View("Index", books);
        }

        public ActionResult Details(int id)
        {
            Book book = serviceUnitOfWork.ServiceBooksRepository.Details(id);

            return View("Details", book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                serviceUnitOfWork.ServiceBooksRepository.AddBook(book);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            Book book = serviceUnitOfWork.ServiceBooksRepository.Details(id);

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                serviceUnitOfWork.ServiceBooksRepository.UpdateBook(book);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            Book book = serviceUnitOfWork.ServiceBooksRepository.Details(id);
            serviceUnitOfWork.ServiceBooksRepository.DeleteBook(book);
            return View("Delete", book);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            Book book = serviceUnitOfWork.ServiceBooksRepository.Details(id);
            serviceUnitOfWork.ServiceBooksRepository.DeleteBook(book);
            return View("Deleted");
        }

        public ActionResult Deleted()
        {
            return View();
        }
    }
}