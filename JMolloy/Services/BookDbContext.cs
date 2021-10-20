using JMolloy.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace JMolloy.Models
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
