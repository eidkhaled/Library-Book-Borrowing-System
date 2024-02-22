using DTOS_BuissnesLogic.Buissneslogic;
using DTOS_BuissnesLogic.DTOs;
using DTOS_BuissnesLogic.InterFaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBookBorrowingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CopyController : ControllerBase
    {
        private readonly IBookCopyRepository _bookCopyRepository;
        public CopyController(IBookCopyRepository bookCopyRepository)
        {
            _bookCopyRepository = bookCopyRepository;
        }
        [HttpPost]
        public async Task<ActionResult<ViewModelForCopiesForAdd>> AddBookCopy(ViewModelForCopiesForAdd Model)
        {
            if (ModelState.IsValid)
            {
                var book = await _bookCopyRepository.AddNewBookCopy(Model);
                return Ok(Model);
            }
            return BadRequest(Model);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewModelForCopies>>> GetAllCopies()
        {
            var Copies = await _bookCopyRepository.GetAllBooksCopy();
            return Ok(Copies);

        }
        [HttpGet("{CopyId}")]
        public async Task<ActionResult<ViewModelForCopies>> GetBookById(int CopyId)
        {
            var Copy = await _bookCopyRepository.GetBookCopyById(CopyId);
            if (Copy == null)
            {
                return BadRequest("not Found");
            }
            return Ok(Copy);

        }
        [HttpPut("{CopyId}")]
        public async Task<ActionResult<ViewModelForCopiesForAdd>> UpdateBook(int CopyId, ViewModelForCopiesForAdd viewModelForCopy)
        {
            if (ModelState.IsValid)
            {
                var EditedCopy = await _bookCopyRepository.UpdateBookCopyiesById(CopyId, viewModelForCopy);
                return Ok(EditedCopy);

            }
            else
            {
                return
                    BadRequest("Can,t update");
            }
        }
        [HttpDelete("{CopyId}")]
        public async Task<ActionResult<bool>> DeleteCoby(int CopyId)
        {
            var Check = await _bookCopyRepository.DeleteBookCopiesById(CopyId);
            if (Check)
                return Ok("Deleted Successfuly");
            return BadRequest("can,t Delete");

        }
    }
}
