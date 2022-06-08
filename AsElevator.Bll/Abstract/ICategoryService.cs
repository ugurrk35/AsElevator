using AsElevator.Entity.Dto;
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
        Task<List<GetCategoryDto>> GetCategoriesID(int id);
        Task<GetCategoryDto> Update(UpdateCategoryDto categoryDto);
    }
}
