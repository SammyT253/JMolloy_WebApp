using JMolloy.Models.Entities;
using System.Collections.Generic;

namespace JMolloy.Services
{
    public interface IBookRepository
    {
        ICollection<Book> ReadAll();
        Book Create(Book book);
        Book Read(int id);
        void Update(int id, Book book);
        void Delete(int id);
    }
}
