using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_ReadingList.Service.Dto;
using Task4_ReadingList.DataAccess.Repositories;
using Task4_ReadingList.DataAccess.Repositories.BookRepository;

namespace Task4_ReadingList.Service.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public BookService(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public void CreateBook(BookDto book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public List<BookDto> GetAllBooks()
        {
            return _mapper.Map<List<BookDto>>(_bookRepository.GetAllBooks());
        }

        public BookDto GetBookById(int id)
        {
            return _mapper.Map<BookDto>(_bookRepository.GetBookById(id));
        }

        public void UpdateBook(BookDto book)
        {
            throw new NotImplementedException();
        }
    }
}
