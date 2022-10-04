using OES.API.Application.Features.Commands.Category.CreateCategory;
using OES.API.Application.Features.Commands.Category.DeleteCategory;
using OES.API.Application.Features.Commands.Category.UpdateCategory;
using OES.API.Application.Features.Queries.Category.GetAllCategories;
using OES.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<CreateCategoryCommandResponse> CreateAsync(Category category);
        Task<UpdateCategoryCommandResponse> UpdateAsync(Category category);
        Task<DeleteCategoryCommandResponse> DeleteAsync(string categoryId);
        Task<GetAllCategoriesQueryResponse> GetAllAsync();
    }
}
