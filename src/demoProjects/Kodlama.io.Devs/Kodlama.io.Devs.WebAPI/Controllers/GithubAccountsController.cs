using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Commands.DeleteGithubAccount;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Commands.CreateGithubAccount;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Commands.DeleteGithubAccount;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Commands.UpdateGithubAccount;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Dtos;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Models;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Queries.GetByIdGithubAccount;
using Kodlama.io.Devs.Application.Features.GithubAccounts.Queries.GetListGithubAccount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubAccountsController : BaseController
    {
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteGithubAccountCommand deleteGithubAccountCommand)
        {
            var result = await Mediator.Send(deleteGithubAccountCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGithubAccountCommand updateGithubAccountCommand)
        {
            var result = await Mediator.Send(updateGithubAccountCommand);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGithubAccountCommand createGithubAccountCommand)
        {
            var result = await Mediator.Send(createGithubAccountCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListGithubAccountQuery getListGithubAccountQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListGithubAccountQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdGithubAccountQuery getByIdGithubAccountQuery)
        {
            var result = await Mediator.Send(getByIdGithubAccountQuery);
            return Ok(result);
        }
    }
}
