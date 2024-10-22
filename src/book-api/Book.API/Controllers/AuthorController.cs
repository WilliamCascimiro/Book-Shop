using Book.Application.DTOs.Author;
using Book.Application.DTOs.Book;
using Book.Application.Interface;
using Book.Application.Services;
using Book.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [ApiController]
    [Route("Author")]
    public class AuthorController : ControllerBase
    {
        protected readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateAuthorRequest createAuthorRequest)
        {
            var success = await _authorService.CreateAsync(createAuthorRequest);

            if (success)
                return BadRequest();

            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var success = await _authorService.GetAll();

            return Ok(success);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await _authorService.GetById(id);

            if (book == null)
            {
                return NotFound("Author not found");
            }

            return Ok(book);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _authorService.Delete(id);

            if (!result)
            {
                return NotFound("Author not found");
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAuthorRequest updateAuthorRequest)
        {
            if (id != updateAuthorRequest.Id)
            {
                return BadRequest("O ID da URL não corresponde ao ID do autor.");
            }

            var result = await _authorService.Update(id, updateAuthorRequest);

            if (!result)
                return BadRequest();

            return Ok();

        }

    }
}
