using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_ReadingList.DataAccess.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRead { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
