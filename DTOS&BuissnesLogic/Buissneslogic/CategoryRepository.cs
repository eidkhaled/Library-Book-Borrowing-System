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
            if (Model == null) return new ViewModelForCategory();
            Category category = new Category()
            {
/*                CategoryId = Model.CategoryId,
*/                CategoryName = Model.CategoryName
/*                ParentCategoryId = Model.ParentCategoryId
*/            };
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            Model.CategoryId=category.CategoryId;
            return Model;
        }


        public async Task<bool> DeleteCategoryById(int CategoryId)
        {
            var category = _dbContext.Categories.Include(x=>x.Books).FirstOrDefault(b => b.CategoryId == CategoryId);
            if (category != null && category.Books.Count ==0)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<ViewModelForCategory>> GetAllCategories()
        {
                var categories = await _dbContext.Categories
           // .Include(x => x.ParentCategory)
         //   .Include(c => c.ChildCategories).Where(x=>x.ParentCategoryId==null)
            .Select(a => new ViewModelForCategory
            {
                CategoryName = a.CategoryName,
                CategoryId = a.CategoryId
              //  ParentCategoryId = a.ParentCategoryId,
             //   ParentCategoryName = a.ParentCategory != null ? a.ParentCategory.CategoryName : null, 
               /* Children = a.ChildCategories.Select(child => new ViewModelForCategory
                {
                    CategoryName = child.CategoryName,
                    CategoryId = child.CategoryId,
                    ParentCategoryId = child.ParentCategoryId,
                    ParentCategoryName = a.CategoryName, 
                    Children = null
                }).ToList()*/
            })
            .ToListAsync();

                return categories;
        }

        public async Task<ViewModelForCategory> GetCategoryById(int CategoryId)
        {
            var categoryEntity = await _dbContext.Categories
       //   .Include(x => x.ParentCategory)
        //  .Include(c => c.ChildCategories)
          .FirstOrDefaultAsync(c => c.CategoryId == CategoryId);

            if (categoryEntity == null)
                return null;

            var viewModel = new ViewModelForCategory
            {
                CategoryId = categoryEntity.CategoryId,
                CategoryName = categoryEntity.CategoryName
          /*      ParentCategoryId = categoryEntity.ParentCategoryId,
                ParentCategoryName = categoryEntity.ParentCategory != null ? categoryEntity.ParentCategory.CategoryName : null,
                Children = categoryEntity.ChildCategories.Select(child => new ViewModelForCategory
                {
                    CategoryId = child.CategoryId,
                    CategoryName = child.CategoryName,
                    ParentCategoryId = child.ParentCategoryId,
                    ParentCategoryName = categoryEntity.CategoryName, 
                    Children = GetChildren(child)
                }).ToList()
*/            };

            return viewModel;
        }
        private List<ViewModelForCategory> GetChildren(Category category)
        {
            return category.ChildCategories.Select(child => new ViewModelForCategory
            {
                CategoryId = child.CategoryId,
                CategoryName = child.CategoryName,
                ParentCategoryId = child.ParentCategoryId,
                ParentCategoryName = category.CategoryName,
                Children = GetChildren(child)
            }).ToList();
        }

        public async Task<ViewModelForCategory> UpdateCategoryById(int CategoryId, ViewModelForCategory model)
        {
            // Retrieve the category entity from the database
            var categoryEntity = await _dbContext.Categories
               /* .Include(x => x.ParentCategory)
                .Include(c => c.ChildCategories)*/
                .FirstOrDefaultAsync(c => c.CategoryId == CategoryId);

            // If the category with the provided ID does not exist, return null
            if (categoryEntity == null)
                return null;

            // Update the properties of the category entity with the values from the provided model
            categoryEntity.CategoryName = model.CategoryName;
           // categoryEntity.ParentCategoryId = model.ParentCategoryId;

            // Update child categories recursively
          //  UpdateChildren(categoryEntity.ChildCategories, model.Children);

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            // Return the updated category
            return model;
        }

        private void UpdateChildren(ICollection<Category> childEntities, List<ViewModelForCategory> childModels)
        {
            // Iterate through child entities and corresponding child models
            foreach (var (childEntity, childModel) in childEntities.Zip(childModels, (e, m) => (e, m)))
            {
                // Update properties of child entity with values from child model
                childEntity.CategoryName = childModel.CategoryName;
                childEntity.ParentCategoryId = childModel.ParentCategoryId;

                // Recursively update child entities' children
                UpdateChildren(childEntity.ChildCategories, childModel.Children);
            }
        }
    }
}
