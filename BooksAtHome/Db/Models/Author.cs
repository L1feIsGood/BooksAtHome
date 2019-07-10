using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAtHome.Db.Models
{
    public class Author : IDbEntity
    {
        public long? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Book Book { get; set; }
    }
}
