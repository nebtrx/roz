using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Roz.Data;
using Roz.Data.EntityFramework;
using Roz.Data.Scope;
using Roz.WebApp.Models;

namespace Roz.WebApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IRepository<int, Book> _repository;
        private BooksDbContext db;
        //private IDataContextScope _scope;

        public BooksController(Roz.Data.IRepository<int, Book> repository)
        {
            _repository = repository;
            //_scope = EFDataEngine.Current.DbContextScopeFactory.Create();
            //db = dataEngine.Current.CurrentDbContextScope.DataContexts.Get<BooksDbContext>();
        }


        // GET: Books
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Book>, List<BookVM>>(_repository.All().ToList()));
            //return View(db.Books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _repository.Find((int) id);

            //Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Book, BookVM>(book));
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BookName,ISBN")] Book book)
        {
            if (ModelState.IsValid)
            {

                _repository.Add(book);
                //db.Books.Add(book);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Mapper.Map<Book, BookVM>(book));
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Book book = db.Books.Find(id);
            Book book = _repository.Find((int) id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Book, BookVM>(book));
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookName,ISBN, RowVersion")] Book book)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(book);
                //db.Entry(book).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Mapper.Map<Book, BookVM>(book));
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Book book = db.Books.Find(id);
            Book book = _repository.Find(id.Value);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Book, BookVM>(book));
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Book book = db.Books.Find(id);
            //db.Books.Remove(book);
            //db.SaveChanges();
            _repository.Delete(_repository.Find(id));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                //_scope.SaveChanges();
                //_scope.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
