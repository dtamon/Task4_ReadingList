using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_ReadingList.DataAccess.Context;
using Task4_ReadingList.DataAccess.Entities;

namespace Task4_ReadingList.DataAccess.Seeder
{
    public class ReadingListSeeder
    {
        private readonly ReadingListDbContext context;

        public ReadingListSeeder(ReadingListDbContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            if (!context.Database.CanConnect())
                return;
            if (!context.Authors.Any())
            {
                context.Authors.AddRange(GetAuthors());
                context.Books.AddRange(GetBooks());
                context.SaveChanges();
            }
        }

        private IEnumerable<Author> GetAuthors() 
        {
            return new List<Author>()
            {
                new Author() { FirstName = "Andrzej", LastName = "Sapkowski"},
                new Author() { FirstName = "John R.R.", LastName = "Tolkien"},
                new Author() { FirstName = "George R.R.", LastName = "Martin"},
            };
        }

        private IEnumerable<Book> GetBooks()
        {
            return new List<Book>()
            {
                new Book() { Title = "Blood of Elves", IsRead = true, AuthorId = 1, Position = null },
                new Book() { Title = "Time of Contempt", IsRead = true, AuthorId = 1, Position = null },
                new Book() { Title = "Baptism of Fire", IsRead = false, AuthorId = 1, Position = 1 },
                new Book() { Title = "The Tower of the Swallow", IsRead = false, AuthorId = 1, Position = 2 },
                new Book() { Title = "The Lady of the Lake", IsRead = false, AuthorId = 1, Position = 3 },
                new Book() { Title = "Silmarillion", IsRead = true, AuthorId = 2, Position = null },
                new Book() { Title = "Thge Lord of the Rings", IsRead = true, AuthorId = 2, Position = null },
                new Book() { Title = "Game of Thrones", IsRead = false, AuthorId = 3, Position = 4 },
                new Book() { Title = "Blood and Fire", IsRead = false, AuthorId = 3, Position = 5 },
            };
        }
    }
}
