using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAtHome.Db.Models
{
    public class Book: IDbEntity
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedOn { get; set; }

        public virtual Author Author { get; set; }
    }
}
