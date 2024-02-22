using DataBase;
using DTOS_BuissnesLogic.DTOs;
using DTOS_BuissnesLogic.InterFaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS_BuissnesLogic.Buissneslogic
{
    public class CategoryRepository :ICategoryRepository
    {
        private AppDbContext _dbContext;
        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ViewModelForCategory> AddNewCategory(ViewModelForCategory Model)
        {
            if (Model == null) return null;
            Category category = new Category()
            {
                CategoryId = Model.CategoryId,
                CategoryName = Model.CategoryName
            };
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            Model.CategoryId=category.CategoryId;
            return Model;
        }


        public async Task<bool> DeleteCategoryById(int CategoryId)
        {
            var category = _dbContext.Categories.FirstOrDefault(b => b.CategoryId == CategoryId);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<ViewModelForCategory>> GetAllCategories()
        {
            var category = await _dbContext.Categories.Select(a => new ViewModelForCategory
            {
                CategoryName = a.CategoryName,
                CategoryId = a.CategoryId,
                
            }).ToListAsync();
                return category; 
        }

        public async Task<ViewModelForCategory> GetCategoryById(int CategoryId)
        {
            var category = _dbContext.Categories.Select(a => new ViewModelForCategory
            {
                CategoryName = a.CategoryName,
                CategoryId = a.CategoryId
            }).FirstOrDefault(b => b.CategoryId == CategoryId);
            if (category != null) { return category; }
            return null;
        }

        public async Task<ViewModelForCategory> UpdateCategoryById(int CategoryId, ViewModelForCategory Model)
        {
            var category = _dbContext.Categories.FirstOrDefault(b => b.CategoryId == CategoryId);
            if (category != null) {

                category.CategoryName = Model.CategoryName;
                  _dbContext.Categories.Update(category);
                 _dbContext.SaveChanges();
                return Model;
          
                    }
            return null;
        }
    }
}
