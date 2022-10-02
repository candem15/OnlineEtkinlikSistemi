using AutoMapper;
using MediatR;
using OES.API.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private ICategoryService _categoryService;
        private IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            UpdateCategoryCommandResponse response = await _categoryService.UpdateAsync(_mapper.Map<Domain.Entities.Category>(request));

            return response;    
        }
    }
}
