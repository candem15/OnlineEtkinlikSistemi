using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OES.API.Application.Features.Commands.Category.CreateCategory;
using OES.API.Application.Features.Commands.Category.DeleteCategory;
using OES.API.Application.Features.Commands.Category.UpdateCategory;

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

        [HttpPost("create-city")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            CreateCategoryCommandResponse response = await _mediatR.Send(createCategoryCommandRequest);
            return Ok(response);
        }

        [HttpPost("update-city")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            UpdateCategoryCommandResponse response = await _mediatR.Send(updateCategoryCommandRequest);
            return Ok(response);
        }

        [HttpDelete("delete-city")]
        [Authorize(AuthenticationSchemes = "Default", Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommandRequest deleteCategoryCommandRequest)
        {
            DeleteCategoryCommandResponse response = await _mediatR.Send(deleteCategoryCommandRequest);
            return Ok(response);
        }
    }
}
