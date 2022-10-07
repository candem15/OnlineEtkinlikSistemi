using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using OES.API.Application.Abstractions.Services;
using OES.API.Application.Dtos.Category;
using OES.API.Application.Features.Commands.Category.CreateCategory;
using OES.API.Application.Features.Commands.Category.DeleteCategory;
using OES.API.Application.Features.Commands.Category.UpdateCategory;
using OES.API.Application.Features.Queries.Category.GetAllCategories;
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
        private IMapper _mapper;
        private IValidator<Category> _validator;
        public CategoryService(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository, IMapper mapper, IValidator<Category> validator)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<CreateCategoryCommandResponse> CreateAsync(Category category)
        {
            ValidationResult result = await _validator.ValidateAsync(category);
            if (!result.IsValid)
            {
                return new CreateCategoryCommandResponse() { Message = "Kategori ismi boş geçilemez!", Succeeded = false };
            }
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

        public async Task<GetAllCategoriesQueryResponse> GetAllAsync()
        {
            List<Category> categories = _categoryReadRepository.GetAll().ToList();
            return new GetAllCategoriesQueryResponse() { Categories = _mapper.Map<List<GetAllCategoriesResponse>>(categories) };
        }

        public async Task<UpdateCategoryCommandResponse> UpdateAsync(Category category)
        {
            ValidationResult result = await _validator.ValidateAsync(category);
            if (!result.IsValid)
            {
                return new UpdateCategoryCommandResponse() { Message = "Kategori ismi boş geçilemez!", Succeeded = false };
            }
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
