using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.Context;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class BookReviewsController : Controller
    {
        private readonly MyDbContext _dbcontext;

        public BookReviewsController(MyDbContext context)
        {
            _dbcontext = context;
        }

        public ActionResult Index()
        {
            try
            {
                var bookVms = _dbcontext.BookReviews
                    .Include(br => br.Book) // Include related Book entity
                    .Include(br => br.User) // Include related User entity
                    .Select(x => new ReviewVM
                    {
                        Id = x.IdbookReview,
                        Rating = x.Rating,
                        Comment = x.Comment,
                        UserId = x.UserId,
                        UserName = x.User.FirstName + " " + x.User.LastName,
                        BookTitle = x.Book.Title
                    }).ToList();
                return View(bookVms);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: BookReviews/Create
        public ActionResult Create()
        {
            var model = new ReviewVM
            {
                UserName = User.Identity.Name,
                UserId = User.GetUserId() // Assuming the extension method GetUserId() as defined earlier
            };

            return View(model);
        }

        // POST: BookReviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewVM reviewVm)
        {
            if (ModelState.IsValid)
            {
                var userId = User.GetUserId();
                var user = _dbcontext.Users.FirstOrDefault(u => u.Iduser == userId);

               

                // Find or create the book based on the title
                var book = _dbcontext.Books.FirstOrDefault(b => b.Title == reviewVm.BookTitle);
                if (book == null)
                {
                    book = new Book { Title = reviewVm.BookTitle };
                    _dbcontext.Books.Add(book);
                    _dbcontext.SaveChanges();
                }

                var bookReview = new BookReview
                {
                    Rating = reviewVm.Rating,
                    Comment = reviewVm.Comment,
                    UserId = 1,
                    BookId = book.Idbook
                };

                _dbcontext.BookReviews.Add(bookReview);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reviewVm);
        }


        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BookReview review)
        {
            try
            {
                var dbReview = _dbcontext.BookReviews.FirstOrDefault(x => x.IdbookReview == id);
                _dbcontext.BookReviews.Remove(dbReview);
                _dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var dbrev = _dbcontext.BookReviews.FirstOrDefault(x => x.IdbookReview == id);
            var rev = new ReviewVM
            {
                Rating= dbrev.Rating,
                Comment = dbrev.Comment,

            };

            return View(rev);
        }

    }
}
