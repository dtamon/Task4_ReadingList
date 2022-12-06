using Microsoft.AspNetCore.Mvc;
using Task4_ReadingList.Service.Dto;
using Task4_ReadingList.Service.Services.AuthorService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task4_ReadingList.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: Author
        [HttpGet]
        public ActionResult<List<AuthorDto>> GetAllAuthorss()
        {
            return Ok(_authorService.GetAllAuthors());
        }

        // GET Author/2
        [HttpGet("{id}")]
        public ActionResult<AuthorDto> GetAuthor(int id)
        {
            return Ok(_authorService.GetAuthorById(id));
        }

        // POST Author
        [HttpPost]
        public ActionResult<AuthorDto> CreateAuthor(AuthorDto author)
        {
            _authorService.CreateAuthor(author);
            return Ok(author);
        }

        // PUT Author/2
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(AuthorDto author)
        {
            _authorService.UpdateAuthor(author);
            return Ok(author);
        }

        // DELETE Author/2
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            _authorService.DeleteAuthor(id);
            return NoContent();
        }
    }
}
