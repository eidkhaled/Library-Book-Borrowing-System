using DataBase;
using DTOS_BuissnesLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS_BuissnesLogic.InterFaces
{
    public interface ICategoryRepository
    {
        Task<ViewModelForCategory> AddNewCategory(ViewModelForCategory Model);
        Task<ViewModelForCategory> GetCategoryById(int CategoryId);
        Task<IEnumerable<ViewModelForCategory>> GetAllCategories();
        Task<ViewModelForCategory> UpdateCategoryById(int CategoryId, ViewModelForCategory Model);
        Task<bool> DeleteCategoryById(int CategoryId);
    }
}
