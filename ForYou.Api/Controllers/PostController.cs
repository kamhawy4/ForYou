using ForYou.Application.Command.Post;
using ForYou.Application.Features.Post.Queries.GetPostDetail;
using ForYou.Application.Features.Post.Queries.GetPostsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("all", Name = "GetALLPosts")]
        public async Task<ActionResult<List<GetPostListQueryViewModel>>> GetAllPosts()
        {

           var allposts  = await _mediator.Send(new GetPostListQuery());

            return Ok(allposts);
        }


        [HttpGet("{id}",Name = "GetPostbyId")]
        public async Task<ActionResult<GetPostByIdQueryViewModel>> GetPostById(Guid Id)
        {
            var getEventDetailQuery = new GetPostByIdQuery() { Id = Id };
            return  Ok( await _mediator.Send(getEventDetailQuery));
        }


        [HttpPut(Name = "UpdatePost")]
        public async Task<ActionResult>update([FromBody] UpdatePostCommend updatePostCommand)
        {
            await _mediator.Send(updatePostCommand);
            return NoContent();
        }


        [HttpDelete("{id}",Name = "DeletePostById")]
        public  async Task<ActionResult> DeletePostById(Guid Id) { 
            await _mediator.Send(new DeletePostCommend() { Id = Id });
            return NoContent();
        }

       
    }
}
