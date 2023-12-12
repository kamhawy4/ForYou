using ForYou.Application.Features.Authentication.Login;
using ForYou.Application.Features.Authentication.Register;
using ForYou.Application.Features.Category.Commands.CreateCategory;
using ForYou.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ForYou.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost(Name = "Login")]
         public async Task<IActionResult> Login([FromBody] LoginCommend loginCommend)
         {
            var token  =  await Mediator.Send(loginCommend);
            return Ok(token);
         }


        [HttpPost(Name = "Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommend registerCommend)
        {
            Guid id = await Mediator.Send(registerCommend);
            return Ok(id);
        }




    }
}
