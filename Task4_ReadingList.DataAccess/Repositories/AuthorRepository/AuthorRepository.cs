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
        private readonly ReadingListDbContext context;
        public AuthorRepository(ReadingListDbContext context) 
        {
            this.context = context;
        }

        public void CreateAuthor(Author author)
        {
            context.Authors.Add(author);
            context.SaveChanges();
        }

        public void DeleteAuthor(Author author)
        {
            context.Authors.Remove(author);
            context.SaveChanges();
        }

        public List<Author> GetAllAuthors()
        {
            return context.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return context.Authors.First(x => x.Id == id);
        }

        public void UpdateAuthor(Author author)
        {
            context.Update(author);
            context.SaveChanges();
        }
    }
}
