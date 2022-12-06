using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_ReadingList.DataAccess.Entities;
using Task4_ReadingList.Service.Dto;

namespace Task4_ReadingList.Service.Services.AuthorService
{
    public interface IAuthorService
    {
        public List<AuthorDto> GetAllAuthors();
        public AuthorDto GetAuthorById(int id);
        public void CreateAuthor(AuthorDto author);
        public void UpdateAuthor(AuthorDto author);
        public void DeleteAuthor(int id);
    }
}
