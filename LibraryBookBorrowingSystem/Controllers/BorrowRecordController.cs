using DataBase;
using DTOS_BuissnesLogic.DTOs;
using DTOS_BuissnesLogic.InterFaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBookBorrowingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowRecordController : ControllerBase
    {
        private readonly IBorrowingRecordsRepository _borrowingRecordsRepository;
        public BorrowRecordController(IBorrowingRecordsRepository borrowingRecordsRepository)
        {

            _borrowingRecordsRepository= borrowingRecordsRepository;
        }

        [HttpPost]
        public async Task<ActionResult<BorrowingRecords>> AddBorrowRecord(ViewModelForBorrow Model)
        {
           
            if (ModelState.IsValid)
            {
                var book = await _borrowingRecordsRepository.AddNewBorrowingRecord(Model);
                if (book != null)
                {
                    return Ok(book);
                }
                return BadRequest("can't add");
            }
            return BadRequest("can't add");
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewModelForBorrow>>> GetAllCopies()
        {
            var Borrows = await _borrowingRecordsRepository.GetAllBorrowingRecords();
            return Ok(Borrows);

        }
        [HttpGet("{BorrowId}")]
        public async Task<ActionResult<ViewModelForBorrowWithId>> GetBookById(int BorrowId)
        {
            var Borrow = await _borrowingRecordsRepository.GetBorrowingRecordById(BorrowId);
            if (Borrow == null)
            {
                return BadRequest("not Found");
            }
            return Ok(Borrow);
        }
        [HttpPut("{BorrowId}")]
        public async Task<ActionResult<ViewModelForBorrow>> UpdateBook(int BorrowId, ViewModelForBorrow viewModelForCopy)
        {
            if (ModelState.IsValid)
            {
                var EditedBorrow = await _borrowingRecordsRepository.UpdateBorrowingRecordById(BorrowId, viewModelForCopy);
                return Ok(EditedBorrow);

            }
            else
            {
                return
                    BadRequest("Can,t update");
            }
        }
    /*    [HttpDelete("{BorrowId}")]
        public async Task<ActionResult<bool>> DeleteCoby(int BorrowId)
        {
            var Check = await _borrowingRecordsRepository.DeleteBorrowingRecordById(BorrowId);
            if (Check)
                return Ok("Deleted Successfuly");
            return BadRequest("can,t Delete");

        }*/


    }
}
