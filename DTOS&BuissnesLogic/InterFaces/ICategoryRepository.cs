using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS_BuissnesLogic.InterFaces
{
    public interface ICategoryRepository
    {
        Task<Category> AddNewCategory(Category Model);
        Task<Category> GetCategoryById(int CategoryId);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> UpdateCategoryById(int CategoryId, Category Model);
        Task<bool> DeleteCategoryById(int CategoryId);
    }
}
