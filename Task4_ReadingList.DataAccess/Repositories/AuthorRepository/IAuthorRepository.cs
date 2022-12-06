using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_ReadingList.DataAccess.Entities;

namespace Task4_ReadingList.DataAccess.Repositories.AuthorRepository
{
    public interface IAuthorRepository
    {
        public List<Author> GetAllAuthors();
        public Author GetAuthorById(int id);
        public void CreateAuthor(Author author);
        public void UpdateAuthor(Author author);
        public void DeleteAuthor(Author author);
    }
}

