using JMolloy.Models.Entities;
using JMolloy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JMolloy.Controllers
{
    public class BooksController : Controller
    {
        private IBookRepository _bookRepo;
        public BooksController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }
        // GET: BooksController
        public IActionResult Index()
        {
            try
            {
                var model = _bookRepo.ReadAll();
                return View(model);
            }
            catch(Exception e)
            {
                throw new Exception("BOOKS CONTROLLER, INDEX METHOD", e);
            }
            
        }

        // GET: BooksController/Details/5
        public IActionResult Details(int id)
        {
            var bookToDetail = _bookRepo.Read(id);
            return View(bookToDetail);
        }

        // GET: BooksController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _bookRepo.Create(book);
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("");
        }

        // GET: BooksController/Edit/5
        public IActionResult Edit(int id)
        {
            var bookToEdit = _bookRepo.Read(id);
            return View(bookToEdit);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book bookToEdit)
        {
            if(ModelState.IsValid)
            {
                _bookRepo.Update(bookToEdit.Id, bookToEdit);
            }
            return RedirectToAction("Index");
        }

        // GET: BooksController/Delete/5
        public IActionResult Delete(int id)
        {
            //read book into var
            var book = _bookRepo.Read(id);
            //if null return index
            if(book == null)
            {
                return RedirectToAction("Index");
            }
            //otherwise return view (book)
            return View(book);
        
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            _bookRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
