using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAtHome.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksAtHome.Db
{
    public class BooksAtHomeContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public BooksAtHomeContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Authors
            modelBuilder.Entity<Author>().ToTable("Authors").HasKey(t => t.Id);
            modelBuilder.Entity<Author>().Property(x => x.FirstName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Author>().Property(x => x.LastName).IsRequired().HasMaxLength(255);
            #endregion

            #region Books
            modelBuilder.Entity<Book>().ToTable("Books").HasKey(t => t.Id);
            modelBuilder.Entity<Book>().Property(x => x.PublishedOn).IsRequired();
            modelBuilder.Entity<Book>().Property(x => x.Title).IsRequired().HasMaxLength(1000);
            modelBuilder.Entity<Book>().HasOne(x => x.Author)
                .WithOne(x => x.Book)
                .HasForeignKey("Author_Id")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
