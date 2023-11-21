using ForYou.Application.Features.Category.Commands.CreateCategory;
using ForYou.Application.Features.Category.Commands.DeleteCategory;
using ForYou.Application.Features.Category.Commands.UpdateCategory;
using ForYou.Application.Features.Category.Queries.GetCategoryDetail;
using ForYou.Application.Features.Category.Queries.GetCategoryList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ForYou.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : BaseController
    {

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryCommend createCategoryCommend)
        {
            Guid id = await Mediator.Send(createCategoryCommend);
            return Ok(id);
        }


        [HttpGet("all", Name = "AllCategory")]
        public async Task<ActionResult<List<GetCategoryListQueryViewModel>>> GetAllCategory()
        {
            var allCategory = await Mediator.Send(new GetCategoryListQuery());

            return Ok(allCategory);

        }

        [HttpGet("{id}", Name = "GetCategorybyId")]
        public async Task<ActionResult<GetCategoryByIdQueryViewModel>> GetCategoryById(Guid Id)
        {
            var CategoryById = await Mediator.Send(new GetCategoryByIdQuery() { Id = Id });
            return Ok(CategoryById);
        }



        [HttpPut(Name = "UpdateCategory")]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryCommend updateCategoryCommend)
        {
            await Mediator.Send(updateCategoryCommend);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteCategoryById")]
        public async Task<ActionResult> DeleteCategoryById(Guid Id)
        {
            await Mediator.Send(new DeleteCategoryCommend() { Id = Id });
            return NoContent();
        }

    }
}

