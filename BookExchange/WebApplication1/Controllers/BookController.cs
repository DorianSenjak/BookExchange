using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Authorize]

    public class BookController : Controller
    {
        
        private readonly MyDbContext _dbContext;
        public BookController(MyDbContext context)
        {
            _dbContext = context;
        }


        // GET: BookController
        public ActionResult Index()
        {

            try
            {
                var bookVms = _dbContext.Books.Select(x => new BookVM
                {
                    Idbook = x.Idbook,
                    Title = x.Title,
                    Author = x.Author,
                    Isbn = x.Isbn,
                    PublicationDate = x.PublicationDate,
                    CoverPageImage = x.CoverPageImage,
                    Publisher = x.Publisher,
                    Pages = x.Pages,
                }).ToList();
                return View(bookVms);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var dbbook = _dbContext.Books.FirstOrDefault(x => x.Idbook == id);
            var bookVM = new BookVM
            {
                Idbook = dbbook.Idbook,
                Title = dbbook.Title,
                Author = dbbook.Author,
                Isbn = dbbook.Isbn,
                PublicationDate = dbbook.PublicationDate,
                CoverPageImage = dbbook.CoverPageImage,
                Publisher = dbbook.Publisher,
                Pages = dbbook.Pages,
            };

            return View(bookVM);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookVM book)
        {
            try
            {
                var newBook = new Book
                {
                    Title = book.Title,
                    Author = book.Author,
                    Isbn = book.Isbn,
                    PublicationDate = book.PublicationDate,
                    CoverPageImage = book.CoverPageImage,
                    Publisher = book.Publisher,
                    Pages = book.Pages,
                };

                _dbContext.Books.Add(newBook);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookVM book)
        {
            try
            {
                var dbBook = _dbContext.Books.FirstOrDefault(x => x.Idbook == id);
                dbBook.Title= book.Title;
                dbBook.Author= book.Author;
                dbBook.Isbn= book.Isbn;
                dbBook.PublicationDate= book.PublicationDate;
                dbBook.CoverPageImage= book.CoverPageImage;
                dbBook.Publisher = book.Publisher;
                dbBook.Pages = book.Pages;

                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,  BookVM book)
        {
            try
            {
                var dbBook = _dbContext.Books.FirstOrDefault(x=>x.Idbook == id);
                _dbContext.Books.Remove(dbBook);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
