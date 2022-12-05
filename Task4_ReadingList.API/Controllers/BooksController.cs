using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task4_ReadingList.DataAccess.Context;
using Task4_ReadingList.DataAccess.Entities;
using Task4_ReadingList.Service.Dto;
using Task4_ReadingList.Service.Services.BookService;

namespace Task4_ReadingList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ReadingListDbContext _context;
        private readonly IBookService _bookService;


        public BooksController(ReadingListDbContext context, IBookService bookService)
        {
            _context = context;
            _bookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetAllBooks()
        {
            return Ok(_bookService.GetAllBooks());
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public ActionResult<BookDto> GetBook(int id)
        {
            return Ok(_bookService.GetBookById(id));
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public IActionResult UpdateBook(BookDto book)
        {
            _bookService.UpdateBook(book);
            return Ok(book);
        }

        // POST: api/Books
        [HttpPost]
        public ActionResult<BookDto> CreateBook(BookDto book)
        {
            _bookService.CreateBook(book);
            return Ok(book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
