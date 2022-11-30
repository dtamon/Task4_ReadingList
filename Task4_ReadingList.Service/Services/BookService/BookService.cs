using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_ReadingList.Service.Dto;
using Task4_ReadingList.DataAccess.Repositories;

namespace Task4_ReadingList.Service.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IMapper mapper;
        public BookService(IMapper mapper)
        {
            this.mapper = mapper;
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
            throw new NotImplementedException();
        }

        public BookDto GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(BookDto book)
        {
            throw new NotImplementedException();
        }
    }
}
