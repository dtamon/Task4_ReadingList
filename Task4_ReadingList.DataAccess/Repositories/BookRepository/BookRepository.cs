using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_ReadingList.DataAccess.Context;
using Task4_ReadingList.DataAccess.Entities;

namespace Task4_ReadingList.DataAccess.Repositories.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly ReadingListDbContext context;

        public BookRepository(ReadingListDbContext context)
        {
            this.context = context;
        }

        public void AddBook(Book book)
        {
            context.Books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            context.Books.Remove(book);
        }

        public List<Book> GetAllBooks()
        {
            return context.Books.Include(x => x.Authors).ToList();
        }

        public Book GetBookById(int id)
        {
            return context.Books.First(x => x.Id == id);
        }

        public void UpdateBook(Book book)
        {
            context.Books.Update(book);
        }
    }
}
