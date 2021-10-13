using Microsoft.EntityFrameworkCore;
using JMolloy.Models.Entities;

namespace JMolloy.Models
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet <Book> Books { get; set; }
    }
}
