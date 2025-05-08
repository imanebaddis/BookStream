using Microsoft.AspNetCore.Mvc;
using MediatR;
using BookStore.Application.Commands.Payments;

namespace BookStore.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentCommand command)
        {
            try
            {
                var paymentSuccess = await _mediator.Send(command);
                return Ok(new { Success = paymentSuccess });
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