using Book.Application.DTOs.Author;
using Book.Application.DTOs.Subject;
using Book.Application.Interface;
using Book.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [ApiController]
    [Route("Subject")]
    public class SubjectController : ControllerBase
    {
        protected readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateSubjectRequest createSubjectRequest)
        {
            var success = await _subjectService.CreateAsync(createSubjectRequest);

            if (!success)
                return BadRequest();

            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var success = await _subjectService.GetAll();

            return Ok(success);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await _subjectService.GetById(id);

            if (book == null)
            {
                return NotFound("Author not found");
            }

            return Ok(book);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _subjectService.Delete(id);

            if (!result)
            {
                return NotFound("Author not found");
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSubjectRequest updateSubjectRequest)
        {
            if (id != updateSubjectRequest.Id)
            {
                return BadRequest("O ID da URL não corresponde ao ID do assunto.");
            }

            var result = await _subjectService.Update(id, updateSubjectRequest);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }

}
