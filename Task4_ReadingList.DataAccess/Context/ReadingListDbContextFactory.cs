using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_ReadingList.DataAccess.Context
{
    internal class ReadingListDbContextFactory : IDesignTimeDbContextFactory<ReadingListDbContext>
    {
        public ReadingListDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReadingListDbContext>();
            return new ReadingListDbContext(optionsBuilder.Options);
        }
    }
}
