using DTOS_BuissnesLogic.Buissneslogic;
using DTOS_BuissnesLogic.DTOs;
using DTOS_BuissnesLogic.InterFaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBookBorrowingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpPost]
        public async Task<ActionResult<ViewModelForCategory>> AddCategory(ViewModelForCategory Model)
        {
            if (ModelState.IsValid)
            {
                var Category = await _categoryRepository.AddNewCategory(Model);
                return Ok(Model);
            }
            return BadRequest(Model);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewModelForCategory>>> GetAllCategories()
        {
            var Categories = await _categoryRepository.GetAllCategories();
            return Ok(Categories);

        }
        [HttpGet("{CategoryId}")]
        public async Task<ActionResult<ViewModelForCategory>> GetCategoryById(int CategoryId)
        {
            var Category = await _categoryRepository.GetCategoryById(CategoryId);
            if (Category == null)
            {
                return BadRequest("not Found");
            }
            return Ok(Category);

        }
        [HttpPut]
        public async Task<ActionResult<ViewModelForCategory>> UpdateCategoryById(int CategoryId, ViewModelForCategory ViewModelForCategory)
        {
            if (ModelState.IsValid)
            {
                var EditedCategory = await _categoryRepository.UpdateCategoryById(CategoryId, ViewModelForCategory);
                return Ok(EditedCategory);

            }
            else
            {
                return
                    BadRequest("Can,t update");
            }



        }
        [HttpDelete("{CategoryId}")]
        public async Task<ActionResult> DeleteCategoryById(int CategoryId)
        {
            var Check = await _categoryRepository.DeleteCategoryById(CategoryId);
            if (Check)
                return Ok(true);
            return BadRequest("can,t Delete");

        }

    }
}
