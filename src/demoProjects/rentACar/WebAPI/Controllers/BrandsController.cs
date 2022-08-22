using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Brands.Commands.CreateBrand;
using RentACar.Application.Features.Brands.Dtos;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand creteBrandCommand)
        {
            CreatedBrandDto result = await Mediator.Send(creteBrandCommand);
            return Created("", result);
        }
    }
}
