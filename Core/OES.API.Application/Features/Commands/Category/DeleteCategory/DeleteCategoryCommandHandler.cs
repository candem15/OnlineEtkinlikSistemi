using MediatR;
using OES.API.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Commands.Category.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private ICategoryService _categoryService;
        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            DeleteCategoryCommandResponse response = await _categoryService.DeleteAsync(request.Id);

            return response;
        }
    }
}
