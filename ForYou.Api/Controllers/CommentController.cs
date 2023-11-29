using ForYou.Application.Command.Commands.CreateComment;
using ForYou.Application.Command.Commands.DeleteComment;
using ForYou.Application.Command.Commands.UpdateComment;
using ForYou.Application.Command.Post;
using ForYou.Application.Features.Comment.Queries.GetCommentsDetail;
using ForYou.Application.Features.Comment.Queries.GetCommentsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ForYou.Api.Controllers
{

    [ApiController]
    [Route("/api/comments")]
    public class CommentController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost(Name = "AddComment")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCommentCommend createCommentCommend)
        {
            Guid id = await _mediator.Send(createCommentCommend);
            return Ok(id);
        }


        [HttpGet("all", Name = "AllComments")]
        public async Task<ActionResult<List<GetCommentListQueryViewModel>>> GetAllComments()
        {
            var allCategory = await _mediator.Send(new GetCommentListQuery());

            return Ok(allCategory);

        }


        [HttpGet("{id}", Name = "GetCommentbyId")]
        public async Task<ActionResult<GetCommentByIdQueryViewModel>> GetCommentById(Guid id)
        {
            var getEventDetailQuery = new GetCommentByIdQuery() { Id = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }


        [HttpPut(Name = "UpdateComment")]
        public async Task<ActionResult> update([FromBody] UpdateCommentCommend updatePostCommand)
        {
            await _mediator.Send(updatePostCommand);
            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteCommentById")]
        public async Task<ActionResult> DeleteCommentById(Guid Id)
        {
            await _mediator.Send(new DeleteCommentCommend() { Id = Id });
            return NoContent();
        }


    }
}
