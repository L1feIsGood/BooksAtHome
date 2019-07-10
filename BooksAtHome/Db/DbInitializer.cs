using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAtHome.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksAtHome.Db
{
    public static class DbInitializer
    {
        public static void InitializeDatabase(BooksAtHomeContext context)
        {
            context.Database.Migrate();

            FillStartupData(context);
        }

        private static void FillStartupData(BooksAtHomeContext context)
        {
            if (context.Books.Any())
                return;

            var authors = GetAuthors();
            var books = GetBooks(authors);

            context.Authors.AddRange(authors);
            context.Books.AddRange(books);

            context.SaveChanges();
        }

        public static List<Author> GetAuthors()
        {
            return new List<Author>
            {
                new Author
                {
                    FirstName = "Jack",
                    LastName = "London"
                },
                new Author
                {
                    FirstName = "Leo",
                    LastName = "Tolstoy"
                },
                new Author
                {
                    FirstName = "Some other",
                    LastName = "Author"
                }
            };
        }

        public static List<Book> GetBooks(List<Author> authors)
        {
            return new List<Book>
            {
                new Book
                {
                    Author = authors[0],
                    PublishedOn = DateTime.MinValue,
                    Title = "Holy Bible"
                },
                new Book
                {
                    Author = authors[1],
                    PublishedOn = DateTime.Now,
                    Title = "Bible Holy"
                },
                new Book
                {
                    Author = authors[2],
                    PublishedOn = DateTime.MaxValue,
                    Title = "Boly Hible"
                }

            };
        }
    }
}
