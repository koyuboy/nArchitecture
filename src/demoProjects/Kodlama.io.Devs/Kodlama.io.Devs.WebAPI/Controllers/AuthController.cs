using Kodlama.io.Devs.Application.Features.Members.Commands.LoginMember;
using Kodlama.io.Devs.Application.Features.Members.Commands.RegisterMember;
using Kodlama.io.Devs.Application.Features.Members.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterMemberCommand registerMemberCommand)
        {
            var result = await Mediator.Send(registerMemberCommand);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginMemberCommand loginMemberCommand)
        {
            var result = await Mediator.Send(loginMemberCommand);

            return Ok(result);
        }
    }
}
