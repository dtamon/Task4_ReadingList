using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_ReadingList.DataAccess.Entities;

namespace Task4_ReadingList.DataAccess.Context
{
    public class ReadingListDbContext : DbContext
    {
        public ReadingListDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
    }
}
