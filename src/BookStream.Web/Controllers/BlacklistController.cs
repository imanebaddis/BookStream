using Microsoft.AspNetCore.Mvc;
using MediatR;
using BookStore.Application.Commands;
namespace BookStream.BookStream.src.BookStream.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlacklistController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlacklistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUserToBlacklist([FromBody] AddUserToBlacklistCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(new { Success = result });
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}