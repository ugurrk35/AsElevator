using AsElevator.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsElevator.Dal.Abstract
{
    public interface ICategoryRepository
    {
        Task AddCategory(Category category);
        /// <summary>
        /// kategoriyi text olarak getirme
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        Task<List<Category>> GetCategories(string searchTerm);
        Task<List<Category>> GetCategoriesId(int id);
        Task<Category> CategoryExists(string name);
    }
}
