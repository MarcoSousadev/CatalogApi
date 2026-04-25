using catalogAPI.Application.DTOs.Requests;
using catalogAPI.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace catalogAPI.API.Controllers.V1.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CategoryRequest), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]CategoryRequest request, [FromServices] ICreateCategoryUseCase useCase)
        {
            await useCase.Execute(request);

            return Created();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromRoute]int id, [FromServices] IGetCategoryByIdUseCase useCase)
        {

            var response = await useCase.Execute(id);

            return Ok(response);
        }
    }
}
