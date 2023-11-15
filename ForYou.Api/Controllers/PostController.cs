using ForYou.Application.Command.Post;
using ForYou.Application.Features.Category.Queries;
using ForYou.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForYou.Api.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost(Name = "AddPost")]
        public async Task<ActionResult<Guid>> Create([FromForm] CreatePostCommend createPostCommand)
        {
            Guid id = await _mediator.Send(createPostCommand);
            return Ok(id);
        }
    }
}
