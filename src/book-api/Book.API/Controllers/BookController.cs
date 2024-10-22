using Book.Application.DTOs.Author;
using Book.Application.DTOs.Book;
using Book.Application.Interface;
using Book.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [ApiController]
    [Route("Book")]
    public class BookController : ControllerBase
    {
        protected readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateBookRequest createBookRequest)
        {
            var success = await _bookService.CreateAsync(createBookRequest);

            if (!success)
                return BadRequest();

            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var success = await _bookService.GetAll();

            return Ok(success);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await _bookService.GetById(id);

            if (book == null)
            {
                return NotFound("Book not found");
            }

            return Ok(book);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _bookService.Delete(id);

            if (!result)
                return NotFound("Author not found");

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookRequest updateBookRequest)
        {
            if (id != updateBookRequest.Id)
            {
                return BadRequest("O ID da URL não corresponde ao ID do assunto.");
            }

            var result = await _bookService.Update(id, updateBookRequest);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
