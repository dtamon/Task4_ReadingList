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
        public void CreateAuthor(Author author);
    }
}

