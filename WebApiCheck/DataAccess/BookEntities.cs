using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPICheck.Domain;

namespace WebApiCheck.DataAccess
{
    public class BookEntities : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}