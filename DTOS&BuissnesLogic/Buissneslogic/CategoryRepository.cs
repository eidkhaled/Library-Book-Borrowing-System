using DataBase;
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

        public async Task<Category> AddNewCategory(Category Model)
        {
            if (Model == null) return null;
            await _dbContext.Categories.AddAsync(Model);
            await _dbContext.SaveChangesAsync();
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

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var category = await _dbContext.Categories.ToListAsync();
            return category;
        }

        public async Task<Category> GetCategoryById(int CategoryId)
        {
            var category = _dbContext.Categories.FirstOrDefault(b => b.CategoryId == CategoryId);
            if (category != null) { return category; }
            return null;
        }

        public async Task<Category> UpdateCategoryById(int CategoryId, Category Model)
        {
            var category = _dbContext.Categories.FirstOrDefault(b => b.CategoryId == CategoryId);
            if (category != null) {

                category.CategoryName = Model.CategoryName;
                category.ParentCategory = Model.ParentCategory;
                  _dbContext.Categories.Update(category);
                 _dbContext.SaveChanges();
                return category;
                    
                    
                    
                    
                    
                    }
            return null;
        }
    }
}
