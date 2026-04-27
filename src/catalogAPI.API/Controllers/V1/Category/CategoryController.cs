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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute]int id, [FromServices] IGetCategoryByIdUseCase useCase)
        {

            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetItens([FromRoute] int page, int pageQuantity, [FromServices] IListAllItensUseCase useCase)
        {

            var response = await useCase.Execute(page, pageQuantity);

            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromServices] IRemoveCategoryUseCase useCase)
        {

            await useCase.Execute(id);

            return Ok();
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] int id, CategoryRequest request , [FromServices] IUpdateCategoryUseCase useCase)
        {

            await useCase.Execute(id, request);

            return Ok();
        }
    }
}
