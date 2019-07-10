using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAtHome.Db;
using BooksAtHome.Db.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksAtHome.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private BooksAtHomeContext context;

        public BooksController(BooksAtHomeContext context)
        {
            this.context = context;
        }

        [HttpGet("[action]")]
        public IEnumerable<Book> GetAllBooks()
        {
#if DEBUG
            var authors = DbInitializer.GetAuthors();
            var books = DbInitializer.GetBooks(authors);
            return books;
#endif
            // No real DB configured due to absence of configured DBMS, therefore no init migration and so on
            return context.Books;
        }
    }
}
