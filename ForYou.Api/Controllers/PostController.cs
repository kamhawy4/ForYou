using ForYou.Application.Command.Post;
using ForYou.Application.Features.Post.Queries.GetPostDetail;
using ForYou.Application.Features.Post.Queries.GetPostsList;
using ForYou.Resources;
using ForYou.SharedServices.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ForYou.Api.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public PostController(IMediator mediator, IStringLocalizer<SharedResource> localizer)
        {
            _mediator = mediator;
            _localizer = localizer;
        }

        [HttpPost(Name = "AddPost")]
        public async Task<ActionResult<Guid>> Create([FromForm] CreatePostCommend createPostCommand)
        {
            Guid id = await _mediator.Send(createPostCommand);
            return Ok(id);
        }

        [HttpGet("localize", Name = "GetLocalizedMessage")]
        public IActionResult GetLocalizedMessage()
        {
            return Ok(_localizer["hello"].Value); // Key in Resource.en.resx or Resource.fr.resx
        }


        [HttpGet("all", Name = "GetALLPosts")]
        public async Task<ActionResult<PaginatedResponseList<GetPostListQueryViewModel>>> GetAllPosts([FromQuery] GetPostListQuery query)
        {
            var allposts = await _mediator.Send(query);

            return Ok(allposts);
        }


        [HttpGet("{id}", Name = "GetPostbyId")]
        public async Task<ActionResult<GetPostByIdQueryViewModel>> GetPostById(Guid id)
        {
            var getEventDetailQuery = new GetPostByIdQuery() { Id = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }


        [HttpPut(Name = "UpdatePost")]
        public async Task<ActionResult> update([FromBody] UpdatePostCommend updatePostCommand)
        {
            await _mediator.Send(updatePostCommand);
            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeletePostById")]
        public async Task<ActionResult> DeletePostById(Guid id)
        {
            await _mediator.Send(new DeletePostCommend() { Id = id });
            return NoContent();
        }


    }
}
