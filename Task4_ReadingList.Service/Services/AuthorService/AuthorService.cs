using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_ReadingList.DataAccess.Entities;
using Task4_ReadingList.DataAccess.Repositories.AuthorRepository;
using Task4_ReadingList.Service.Dto;

namespace Task4_ReadingList.Service.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IMapper mapper, IAuthorRepository authorRepository)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public void CreateAuthor(AuthorDto author)
        {
            _authorRepository.CreateAuthor(_mapper.Map<Author>(author));
        }

        public void DeleteAuthor(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            _authorRepository.DeleteAuthor(author);
        }

        public List<AuthorDto> GetAllAuthors()
        {
            return _mapper.Map<List<AuthorDto>>(_authorRepository.GetAllAuthors());
        }

        public AuthorDto GetAuthorById(int id)
        {
            return _mapper.Map<AuthorDto>(_authorRepository.GetAuthorById(id));
        }

        public void UpdateAuthor(AuthorDto author)
        {
            _authorRepository.UpdateAuthor(_mapper.Map<Author>(author));
        }
    }
}
