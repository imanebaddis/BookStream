using BookStream.Application.Books.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BookStream.Application.Common.Interfaces.Services;
using BookStream.Web.Books.Dtos;

namespace BookStream.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksAsync()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);

        }
         [HttpGet("{id}")]
                public async Task<ActionResult<BookDto>> GetById(int id)
                {
                    var book = await _bookService.GetBookByIdAsync(id);
                    return Ok(book);
                }
 [HttpPost]
        public async Task<ActionResult<BookDto>> Create([FromBody] CreateBookRequest request)
        {
            var book = await _bookService.CreateBookAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }
 [HttpPut("{id}")]
        public async Task<ActionResult<BookDto>> Update(int id, [FromBody] UpdateBookRequest request)
        {
            var book = await _bookService.UpdateBookAsync(id, request);
            return Ok(book);
        }
  [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }

    }
}