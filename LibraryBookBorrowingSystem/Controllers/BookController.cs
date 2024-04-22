using DataBase;
using DTOS_BuissnesLogic.DTOs;
using DTOS_BuissnesLogic.InterFaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<viewModelForBook>>> GetAllBook()
        {
            var Books= await _bookRepository.GetAllBooks();
            return Ok(Books);

        }
        [HttpGet("{BookId}")]
        public async Task<ActionResult<viewModelForBook>> GetBookById(int BookId)
        {
            var Book = await _bookRepository.GetBookById(BookId);
            if(Book == null)
            {
                return BadRequest("not Found");
            }
            return Ok(Book);

        }
        [HttpPut]
        public async Task<ActionResult<viewModelForBook>> UpdateBook(int BookId,viewModelForBook viewModelForBook )
        {
            if (ModelState.IsValid)
            {
                var EditedBook= await _bookRepository.UpdateBookById(BookId, viewModelForBook);
                return Ok(EditedBook);

            }
            else 
            {
                return
                    BadRequest("Can,t update");
            }



        }
        [HttpDelete("{BookId}")]
        public async Task<ActionResult<bool>> DeleteBook(int BookId)
        {
            var Check = await _bookRepository.DeleteBookById(BookId);
            if(Check)
            return Ok(true);
            return Ok(false);

        }

        

    }
}
