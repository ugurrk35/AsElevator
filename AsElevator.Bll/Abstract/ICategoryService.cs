using AsElevator.Entity.Dto;
using AsElevator.Entity.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsElevator.Bll.Abstract
{
    public interface ICategoryService
    {
        Task<List<GetCategoryDto>> GetCategories(string searchTerm);
        Task<GetCategoryDto> Post(CreateCategoryDto categoryDto);
        Task<IResponse<List<GetCategoryDto>>> GetCategoriesID(int id);

         Task<UpdateCategoryDto> Update(UpdateCategoryDto categoryDto, int id);
        Task<CategoryDto> Delete(int categoryId);
        Task<bool> DeleteByIdAsync(int id);

        Task<GetCategoryDto> Update(UpdateCategoryDto categoryDto);
        Task<IResponse<List<GetListCategory>>> GetAllCategory();

    }
}
