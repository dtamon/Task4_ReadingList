using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_ReadingList.DataAccess.Context;

namespace Task4_ReadingList.DataAccess.Repositories.AuthorRepository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ReadingListDbContext context;
        public AuthorRepository(ReadingListDbContext context) 
        {
            this.context = context;
        }
    }
}
