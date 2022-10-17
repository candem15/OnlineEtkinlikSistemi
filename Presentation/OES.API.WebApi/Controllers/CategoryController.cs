using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OES.API.Application.Features.Commands.Category.CreateCategory;
using OES.API.Application.Features.Commands.Category.DeleteCategory;
using OES.API.Application.Features.Commands.Category.UpdateCategory;
using OES.API.Application.Features.Queries.Category.GetAllCategories;
using OES.API.Application.Validators;

namespace OES.API.WebApi.Controllers
{
    [EnableCors("ClientPolicy")]
    [Route("api/[controller]")]
    [Produces("application/json")]
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
            ValidationResult result = new CreateCategoryValidator().Validate(createCategoryCommandRequest);
            if (!result.IsValid)
                return BadRequest(result);
            CreateCategoryCommandResponse response = await _mediatR.Send(createCategoryCommandRequest);
            return Ok(response);
        }

        [HttpPost("update-category")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            ValidationResult result = new UpdateCategoryValidator().Validate(updateCategoryCommandRequest);
            if (!result.IsValid)
                return BadRequest(result);
            UpdateCategoryCommandResponse response = await _mediatR.Send(updateCategoryCommandRequest);
            return Ok(response);
        }

        [HttpDelete("delete-category/{id}")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory([FromRoute] DeleteCategoryCommandRequest deleteCategoryCommandRequest)
        {
            DeleteCategoryCommandResponse response = await _mediatR.Send(deleteCategoryCommandRequest);
            return Ok(response);
        }

        [HttpGet("get-all-categories")]
        public async Task<IActionResult> GetAllCategories([FromQuery] GetAllCategoriesQueryRequest getAllCategoriesQueryRequest)
        {
            GetAllCategoriesQueryResponse response = await _mediatR.Send(getAllCategoriesQueryRequest);
            return Ok(response);
        }
    }
}
