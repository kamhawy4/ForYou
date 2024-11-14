using ForYou.Application.Common.Models;
using ForYou.Application.Features.Category.Commands.CreateCategory;
using ForYou.Application.Features.Category.Commands.DeleteCategory;
using ForYou.Application.Features.Category.Commands.UpdateCategory;
using ForYou.Application.Features.Category.Queries.GetCategoryDetail;
using ForYou.Application.Features.Category.Queries.GetCategoryList;
using ForYou.Domain.Contracts;
using ForYou.SharedServices.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForYou.Api.Controllers
{

    //[Authorize]
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : BaseController
    {

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<Result<string>>> Create([FromBody] CreateCategoryCommend createCategoryCommend)
        {
            Result<string> data = await Mediator.Send(createCategoryCommend);
            return Ok(data);
        }


        [HttpGet("all", Name = "AllCategory")]
        public async Task<ActionResult<TResponse<List<GetCategoryListQueryViewModel>>>> GetAllCategory()
        {
      
            var allCategory = await Mediator.Send(new GetCategoryListQuery());

            return Ok(allCategory);
            
        }

        [HttpGet("{id}", Name = "GetCategorybyId")]
        public async Task<ActionResult<GetCategoryByIdQueryViewModel>> GetCategoryById(Guid id)
        {
            var CategoryById = await Mediator.Send(new GetCategoryByIdQuery() { Id = id });
            return Ok(CategoryById);
        }


        [HttpPut(Name = "UpdateCategory")]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryCommend updateCategoryCommend)
        {
            await Mediator.Send(updateCategoryCommend);
            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteCategoryById")]
        public async Task<ActionResult> DeleteCategoryById(Guid id)
        {
            await Mediator.Send(new DeleteCategoryCommend() { Id = id });
            return NoContent();
        }

    }
}

