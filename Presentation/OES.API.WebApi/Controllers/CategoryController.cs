using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OES.API.Application.Features.Commands.Category.CreateCategory;
using OES.API.Application.Features.Commands.Category.DeleteCategory;
using OES.API.Application.Features.Commands.Category.UpdateCategory;
using OES.API.Application.Features.Queries.Category.GetAllCategories;

namespace OES.API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly IMediator _mediatR;
        public CategoryController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpPost("create-category")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            CreateCategoryCommandResponse response = await _mediatR.Send(createCategoryCommandRequest);
            return Ok(response);
        }

        [HttpPost("update-category")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            UpdateCategoryCommandResponse response = await _mediatR.Send(updateCategoryCommandRequest);
            return Ok(response);
        }

        [HttpDelete("delete-category/{id}")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory([FromRoute]DeleteCategoryCommandRequest deleteCategoryCommandRequest)
        {
            DeleteCategoryCommandResponse response = await _mediatR.Send(deleteCategoryCommandRequest);
            return Ok(response);
        }

        [HttpGet("get-all-categories")]
        public async Task<IActionResult> GetAllCategories([FromQuery]GetAllCategoriesQueryRequest getAllCategoriesQueryRequest)
        {
            GetAllCategoriesQueryResponse response = await _mediatR.Send(getAllCategoriesQueryRequest);
            return Ok(response);
        }
    }
}
