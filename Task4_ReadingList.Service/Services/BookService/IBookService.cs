using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_ReadingList.Service.Dto;

namespace Task4_ReadingList.Service.Services.BookService
{
    public interface IBookService
    {
        public List<BookDto> GetAllBooks();
        public BookDto GetBookById(int id);
        public void CreateBook(BookDto book);
        public void UpdateBook(BookDto book);
        public void DeleteBook(int id);
    }
}
