using System.Collections.Generic;
using System.Web.Mvc;
using TDDMVCApplication.Models.DBDirect;

namespace TDDMVCApplication.Controllers
{
    public class BooksController : Controller
    {
        private UnitOfWork unitOfWork = null;

        public BooksController()
            : this(new UnitOfWork())
        {

        }

        public BooksController(UnitOfWork uow)
        {
            this.unitOfWork = uow;
        }

        public ActionResult Index()
        {
            List<Book> books = unitOfWork.BooksRepository.GetAllBooks();
            return View("Index", books);
        }

        public ActionResult Details(int id)
        {
            Book book = unitOfWork.BooksRepository.GetBookById(id);

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
                unitOfWork.BooksRepository.AddBook(book);
                unitOfWork.BooksRepository.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            Book book = unitOfWork.BooksRepository.GetBookById(id);

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.BooksRepository.UpdateBook(book);
                unitOfWork.BooksRepository.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            Book book = unitOfWork.BooksRepository.GetBookById(id);
            unitOfWork.BooksRepository.DeleteBook(book);
            return View("Delete",book);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            Book book = unitOfWork.BooksRepository.GetBookById(id);
            unitOfWork.BooksRepository.DeleteBook(book);
            unitOfWork.BooksRepository.Save();
            return View("Deleted");
        }

        public ActionResult Deleted()
        {
            return View();
        }
    }
}