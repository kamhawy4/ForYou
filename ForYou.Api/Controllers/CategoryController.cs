using ForYou.Application.Command.Post;
using ForYou.Application.Features.Category.Commands.CreateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ForYou.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryCommend createCategoryCommend)
        {
            Guid id = await _mediator.Send(createCategoryCommend);
            return Ok(id);
        }

    }
}

