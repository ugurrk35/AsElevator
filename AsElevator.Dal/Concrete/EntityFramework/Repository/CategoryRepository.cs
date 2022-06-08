using AsElevator.Dal.Abstract;
using AsElevator.Dal.Concrete.EntityFramework.Context;
using AsElevator.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsElevator.Dal.Concrete.EntityFramework.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> CategoryExists(string name)
        {
            var exist = await _context.Categories.FirstOrDefaultAsync(a => a.Name.Trim() == name.Trim());
            return exist;
        }

        public async Task<List<Category>> GetCategories(string searchTerm)
        {
            return await _context.Categories.Where(a => a.Name.ToLower().Trim().Contains(searchTerm.ToLower()))
                                            .Take(10)
                                            .ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesId(int id)
        {       
            return await _context.Categories.Where(a => a.Id == id).ToListAsync();
                                                                            
        }

        public async Task<Category> Update(Category category)
        {
            _context.Set<Category>().Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category> CategoryExistsId(int id)
        {
            var exist = await _context.Categories.FirstOrDefaultAsync(a => a.Id==id);
            return exist;
        }

    }
}
