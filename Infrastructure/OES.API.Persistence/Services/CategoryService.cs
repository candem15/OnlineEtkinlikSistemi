using OES.API.Application.Abstractions.Services;
using OES.API.Application.Features.Commands.Category.CreateCategory;
using OES.API.Application.Features.Commands.Category.DeleteCategory;
using OES.API.Application.Features.Commands.Category.UpdateCategory;
using OES.API.Application.Repositories;
using OES.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryWriteRepository _categoryWriteRepository;
        private ICategoryReadRepository _categoryReadRepository;
        public CategoryService(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }
        public async Task<CreateCategoryCommandResponse> CreateAsync(Category category)
        {
            bool categoryExists = _categoryReadRepository.GetWhere(x => x.CategoryName == category.CategoryName).Any();
            if (categoryExists)
            {
                return new CreateCategoryCommandResponse() { Message = "Bu isimde hali hazırda bir kategory vardır!", Succeeded = false };
            }
            else
            {
                await _categoryWriteRepository.AddAsync(category);
                await _categoryWriteRepository.SaveChangesAsync();
                return new CreateCategoryCommandResponse() { Message = $"{category.CategoryName} isimli kategori başarıyla oluşturulmuştur!", Succeeded = true };
            }
        }

        public async Task<DeleteCategoryCommandResponse> DeleteAsync(string categoryId)
        {
            Category categoryToDelete = await _categoryReadRepository.GetByIdAsync(categoryId);
            if (categoryToDelete == null)
                return new DeleteCategoryCommandResponse { Message = "Silmek istediğiniz şehir mevcut değildir!", Succeeded = false };
            await _categoryWriteRepository.RemoveAsync(categoryId);
            await _categoryWriteRepository.SaveChangesAsync();
            return new DeleteCategoryCommandResponse { Message = $"{categoryToDelete.CategoryName} isimli kategori başarıyla silinmiştir!", Succeeded = true };
        }

        public async Task<UpdateCategoryCommandResponse> UpdateAsync(Category category)
        {
            Category categoryToUpdate = await _categoryReadRepository.GetByIdAsync(category.Id.ToString());
            if (categoryToUpdate == null)
            {
                return new UpdateCategoryCommandResponse { Message = "Adını güncellemek istediğiniz kategori mevcut değildir!", Succeeded = false };
            }
            else
            {
                categoryToUpdate.CategoryName = category.CategoryName;
                _categoryWriteRepository.Update(categoryToUpdate);
                await _categoryWriteRepository.SaveChangesAsync();
                return new UpdateCategoryCommandResponse { Message = $"Kategori ismi {categoryToUpdate.CategoryName} olarak başarıyla güncellenmiştir!" };
            }
        }
    }
}
