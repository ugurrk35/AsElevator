using AsElevator.Bll.Abstract;
using AsElevator.Dal.Abstract;
using AsElevator.Entity.Dto;
using AsElevator.Entity.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsElevator.Bll.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Task<CategoryDto> Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category != null)
            {
                await _categoryRepository.Delete(category);

               return true;
            }
            else
            {
                throw new ValidationException("kategori bulunmadı");
            }
        }

        public async Task<List<GetCategoryDto>> GetCategories(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                throw new ValidationException("Search term cannot be empty");
            }
            return _mapper.Map<List<GetCategoryDto>>(await _categoryRepository.GetCategories(searchTerm));
        }

        public async Task<List<GetCategoryDto>> GetCategoriesID(int id)
        {
            return _mapper.Map<List<GetCategoryDto>>(await _categoryRepository.GetCategoriesId(id));
        }

        public async Task<GetCategoryDto> Post(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var existingCat = await _categoryRepository.CategoryExists(categoryDto.Name);
            //
            if (string.IsNullOrWhiteSpace(categoryDto.Name))
            {
                throw new ValidationException("Category name cannot be null or empty");
            }

            if (existingCat != null)
            {
                var existingCategoryForGetDto = _mapper.Map<GetCategoryDto>(existingCat);
                return existingCategoryForGetDto;
            }
            await _categoryRepository.AddCategory(category);
            var categoryForGetDto = _mapper.Map<GetCategoryDto>(category);
            return categoryForGetDto;
        }

    

        public async Task<UpdateCategoryDto> Update(UpdateCategoryDto categoryDto, int id)
        {
            var ownerEntity = await _categoryRepository.GetCategory(id);
            _mapper.Map<GetCategoryDto>(ownerEntity);
            _mapper.Map(categoryDto, ownerEntity);
            await _categoryRepository.Update(ownerEntity,id);

            return categoryDto;
        }

        public Task<GetCategoryDto> Update(UpdateCategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
