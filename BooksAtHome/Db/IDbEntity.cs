using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAtHome.Db
{
    public interface IDbEntity
    {
        long? Id { get; set; }
    }
}
