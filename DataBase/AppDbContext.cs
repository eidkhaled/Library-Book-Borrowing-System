using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
            .HasKey(nameof(BookAuthor.AuthorId), nameof(BookAuthor.BookId));
            
        }

        public DbSet<Book> Books{ get; set; }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<BookAuthor> BookAuthors{ get; set; }
        public DbSet<BookCopy> BookCopies{ get; set; }
        public DbSet<BorrowingRecords> BorrowingRecords{ get; set; }
        public DbSet<Category> Categories{ get; set; }

    }

}
