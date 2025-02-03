
using BookStream.Application.Categories.Commands.CreateCategory;
using BookStream.Application.Categories.Queries.GetAllActiveCategories;
using BookStream.Application.Categories.Queries.GetSigneCategory;
using BookStream.Domain.Common.Enums;
using BookStream.Web.Categories.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStream.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController:ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IMediator _mediator;

        public CategoriesController(ILogger<CategoriesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryRequest request)
        {
            var command = new CreateCategoryCommand{Name = request.Title};
            var result = await _mediator.Send(command);
            if(result.IsSuccess)
            {
                return Ok(result.Value);
            }
            
            if(result.Error.ErrorType is ErrorType.Validation)
            {
                return BadRequest(result.Error.Code);
            }

            return StatusCode(500);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActiveCategoriesAsync([FromQuery] GetAllActiveCategoriesWithPaginationRequest request)
        {
            var command = new GetAllActiveCategoriesWithPaginationQuery{ From =(request.PageNumber-1)*request.PageSize,To =request.PageNumber* request.PageSize-1};
            var categoryies = await _mediator.Send(command);
            return Ok(categoryies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(Guid id)
        {
            var command = new GetSingleCategoryQuery{Id = id};
            var result = await _mediator.Send(command);

            if(result.IsSuccess)
            {
                  return Ok(result.Value);
            }

            return NotFound();

          
        }
    }
}