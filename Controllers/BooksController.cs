using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _service;

        public BooksController(IBooksService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _service.GetBooks();
            if (!books.Any())
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _service.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet("search")]
        public IActionResult SearchBooks([FromQuery] string title)
        {
            var books = _service.GetBooksByTitle(title);
            if (!books.Any())
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }
            _service.AddBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }
            _service.UpdateBook(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var existingBook = _service.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            _service.DeleteBook(id);
            return NoContent();
        }
    }
}
