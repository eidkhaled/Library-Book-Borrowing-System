using DataBase;
using DTOS_BuissnesLogic.DTOs;
using DTOS_BuissnesLogic.InterFaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBookBorrowingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository=bookRepository;
        }
        [HttpPost]
        public async Task<ActionResult<viewModelForBook>> AddBook( viewModelForBook Model)
        {
            if(ModelState.IsValid)
            {
                var book= await _bookRepository.AddNewBook(Model);
                return Ok(Model);
            }
            return BadRequest(Model);
        }


    }
}
