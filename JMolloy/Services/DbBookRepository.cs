using JMolloy.Models;
using JMolloy.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JMolloy.Services
{
    public class DbBookRepository : IBookRepository
    {
        private BookDbContext _db;
        public DbBookRepository(BookDbContext db)
        {
            _db = db;
        }
        public Book Create(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return book;
        }

        public void Delete(int id)
        {
            Book bookToDelete = Read(id);
            _db.Remove(bookToDelete);
            _db.SaveChanges();
        }

        public Book Read(int id)
        {
            Book bookToReturn = _db.Books.Find(id);
            return bookToReturn;
        }

        public ICollection<Book> ReadAll()
        {
            try
            {
                return _db.Books.ToList();
            }
            catch(Exception e)
            {
                throw new Exception("***Error inReadAll method, DbBookRepo", e);
            }
           
        }

        public void Update(int id, Book book)
        {
            Book bookToUpdate = Read(id);
            bookToUpdate.Title = book.Title;
            bookToUpdate.AuthorsName = book.AuthorsName;
            bookToUpdate.AmazonLink = book.AmazonLink;
            bookToUpdate.PublicationYear = book.PublicationYear;
            _db.SaveChanges();
        }
    }
}
