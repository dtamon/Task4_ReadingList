using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_ReadingList.DataAccess.Context;
using Task4_ReadingList.DataAccess.Entities;

namespace Task4_ReadingList.DataAccess.Repositories.AuthorRepository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ReadingListDbContext _context;
        public AuthorRepository(ReadingListDbContext context) 
        {
            _context = context;
        }

        public void CreateAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }
}
