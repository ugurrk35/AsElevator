﻿using AsElevator.Dal.Abstract;
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

        public  Task<Category> Update(Category category,int id)
        {
            
                if (category == null)
                {
                    throw new ArgumentNullException("item");
                }

                var item = _context.Categories.FirstOrDefaultAsync(q => q.Id == id);

                if (item == null)
                {
                    throw new ArgumentNullException("product");
                }
                _context.Categories.Update(category);
                _context.SaveChanges();
                return item;
            
        }

       
        public async Task<Category> CategoryExistsId(int id)
        {
            var exist = await _context.Categories.FirstOrDefaultAsync(a => a.Id==id);
            return exist;
        }

        public Task<Category> GetCategory(int id)
        {
            var category = _context.Categories.FirstOrDefaultAsync(q => q.Id == id);
            return category;    
        }

    
        public async Task  Delete(Category category)
        {
            await Task.Run(() => { _context.Set<Category>().Remove(category); });
            _context.SaveChanges();
        }
    }
}
