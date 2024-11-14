using ForYou.Application.Features.Tag.Commends.CreateTag;
using ForYou.Application.Features.Tag.Commends.DeleteTag;
using ForYou.Application.Features.Tag.Commends.UpdateTag;
using ForYou.Application.Features.Tag.Queries.GetTagDetail;
using ForYou.Application.Features.Tag.Queries.GetTagList;
using ForYou.SharedServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForYou.Api.Controllers
{

    [ApiController]
    [Route("api/tags")]
    public class TagController : BaseController
    {

        [HttpPost(Name = "AddTag")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTagCommend createTagCommend)
        {
            Guid id = await Mediator.Send(createTagCommend);
            return Ok(id);
        }


        [HttpGet("all", Name = "AllTag")]
        public async Task<ActionResult<TResponse<List<GetTagListQueryViewModel>>>> GetAllTag()
        {

            var allTag = await Mediator.Send(new GetTagListQuery());

            return Ok(allTag);

        }

        [HttpGet("{id}", Name = "GetTagbyId")]
        public async Task<ActionResult<GetTagByIdQueryViewModel>> GetTagById(Guid id)
        {
            var TagById = await Mediator.Send(new GetTagByIdQuery() { Id = id });
            return Ok(TagById);
        }


        [HttpPut(Name = "UpdateTag")]
        public async Task<ActionResult> UpdateTag([FromBody] UpdateTagCommend updateTagCommend)
        {
            await Mediator.Send(updateTagCommend);
            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteTagById")]
        public async Task<ActionResult> DeleteTagById(Guid id)
        {
            await Mediator.Send(new DeleteTagCommend() { Id = id });
            return NoContent();
        }

    }
}
