using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using AutoMapper;
using Roz.Data;
using Roz.Data.EntityFramework;
using Roz.WebApp.Models;

namespace Roz.WebApp.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IRepository<int, Review> _repository;
        private readonly IRepository<int, Book> _repositoryBooks;
        private BooksDbContext db;


        public ReviewsController(Roz.Data.IRepository<int, Review> repository, IRepository<int, Book> repositoryBooks)
        {
            _repository = repository;
            _repositoryBooks = repositoryBooks;
            //db = dataEngine.Current.CurrentDbContextScope.DataContexts.Get<BooksDbContext>();
        }

        // GET: Reviews
        public ActionResult Index()
        {
            //var reviews = db.Reviews.Include(r => r.Book);

            return View(Mapper.Map<List<Review>, List<ReviewVM>>(_repository.All().Include(r => r.Book).ToList()));
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Review review = db.Reviews.Find(id);
            Review review = _repository.Find((int)id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Review, ReviewVM>(review));
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(Mapper.Map<List<Book>, List<BookVM>>(_repositoryBooks.All().ToList()), "Id", "BookName");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BookID,ReviewText, RowVersion")] Review review)
        {
            if (ModelState.IsValid)
            {
                //db.Reviews.Add(review);
                //db.SaveChanges();
                _repository.Add(review);
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(Mapper.Map<List<Book>,List<BookVM>> (_repositoryBooks.All().ToList()), "Id", "BookName", review.BookID);
            return View(Mapper.Map<Review, ReviewVM>(review));
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Review review = db.Reviews.Find(id);
            Review review = _repository.Find((int)id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(Mapper.Map<List<Book>, List<BookVM>>(_repositoryBooks.All().ToList()), "Id", "BookName", review.BookID);
            return View(Mapper.Map<Review, ReviewVM>(review));
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookID,RowVersion,ReviewText")] Review review)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(review).State = EntityState.Modified;
                //db.SaveChanges();
                _repository.Update(review);
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.Books, "Id", "BookName", review.BookID);
            return View(Mapper.Map<Review, ReviewVM>(review));
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Review review = db.Reviews.Find(id);
            Review review = _repository.Find((int)id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Review, ReviewVM>(review));
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Review review = db.Reviews.Find(id);
            //db.Reviews.Remove(review);
            //db.SaveChanges();
            _repository.Delete(_repository.Find(id));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
