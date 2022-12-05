using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_ReadingList.DataAccess.Entities;

namespace Task4_ReadingList.DataAccess.Repositories.BookRepository
{
    public interface IBookRepository
    {
        public List<Book> GetAllBooks();
        public Book GetBookById(int id);
        public void CreateBook(Book book);
        public void UpdateBook(Book book);
        public void DeleteBook(Book book);
    }
}
