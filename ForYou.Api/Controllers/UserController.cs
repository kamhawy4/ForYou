using ForYou.Application.Features.Authentication.Login;
using ForYou.Application.Features.Authentication.RefreshToken;
using ForYou.Application.Features.Authentication.Register;
using ForYou.SharedServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForYou.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class UserController : BaseController
    {

        [HttpPost("Login")]
        public async Task<ActionResult<TResponse<LoginResponse>>> Login([FromBody] LoginCommend loginCommend)
        {
            var token = await Mediator.Send(loginCommend);
            return Ok(token);
        }


        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] RegisterCommend registerCommend)
        {
            Guid id = await Mediator.Send(registerCommend);
            return Ok(id);
        }


        [HttpPost("RefreshToken")]
        public async Task<ActionResult<TResponse<RefreshTokenResponce>>> RefreshToken([FromBody] TokenModel tokenModel)
        {
            var token = await Mediator.Send(tokenModel);
            return Ok(token);
        }




    }
}
