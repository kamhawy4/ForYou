using ForYou.Application.Command.Post;
using ForYou.Application.Features.Category.Commands.CreateCategory;
using ForYou.Application.Features.Category.Commands.DeleteCategory;
using ForYou.Application.Features.Category.Commands.UpdateCategory;
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

        [HttpPut(Name = "UpdateCategory")]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryCommend updateCategoryCommend)
        {
            await _mediator.Send(updateCategoryCommend);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteCategoryById")]
        public async Task<ActionResult> DeleteCategoryById(Guid Id)
        {
            await _mediator.Send(new DeleteCategoryCommend() { Id = Id });
            return NoContent();
        }

    }
}

