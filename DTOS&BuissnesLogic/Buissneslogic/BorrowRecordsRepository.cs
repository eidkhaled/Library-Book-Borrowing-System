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
    public class BorrowRecordsRepository:IBorrowingRecordsRepository
    {

        private AppDbContext _dbContext;
        public BorrowRecordsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ViewModelForBorrow> AddNewBorrowingRecord(ViewModelForBorrow Model)
        {
            if (Model == null) return null;
            var a=_dbContext.Books.FirstOrDefault(a => a.BookID == Model.bookId);
            var AvailableCopies = CalculateAvailableCopies(Model.bookId);
            if (AvailableCopies >= 1)
            {
                BorrowingRecords borrowingRecords = new BorrowingRecords()
                {
                    bookId = Model.bookId,
                    borrowerAddress=Model.borrowerAddress,
                    borrowerName=Model.borrowerName,
                    phoneNumber=Model.phoneNumber,
                    BorrowDate = DateTime.Now,
                };
                await _dbContext.BorrowingRecords.AddAsync(borrowingRecords);
                await _dbContext.SaveChangesAsync();
                return Model;

            }
            return null;
            
        }

        

/*        public async Task<bool> DeleteBorrowingRecordById(int BorrowingRecordId)
        {
            var BorrowRecord = _dbContext.BorrowingRecords.FirstOrDefault(b => b.BorrowId== BorrowingRecordId);
            if (BorrowRecord != null)
            {
                _dbContext.BorrowingRecords.Remove(BorrowRecord);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }*/

        

        public async Task<IEnumerable<ViewModelForBorrowWithId>> GetAllBorrowingRecords()
        {
            var BorrowingRecords = await _dbContext.BorrowingRecords.Include(x=>x.book).
                Select(a=>new ViewModelForBorrowWithId
                {
                    borrowId = a.borrowId,
                    bookId = a.bookId,
                    bookName=a.book.Title,
                    borrowerAddress = a.borrowerAddress,
                    borrowerName = a.borrowerName,
                    phoneNumber = a.phoneNumber,
                    BorrowDate = a.BorrowDate,
                    ReturnDate = a.ReturnDate
                }).ToListAsync();
            return BorrowingRecords;
        }

        
        public async Task<ViewModelForBorrowWithId> GetBorrowingRecordById(int BorrowingRecordId)
        {
            var BorrowingRecord = _dbContext.BorrowingRecords.Select(a=>new ViewModelForBorrowWithId
            {borrowId=a.borrowId, bookId = a.bookId, BorrowDate = a.BorrowDate,
                borrowerAddress = a.borrowerAddress,
                borrowerName = a.borrowerName,
                phoneNumber = a.phoneNumber,
                ReturnDate = a.ReturnDate }).FirstOrDefault(b => b.borrowId == BorrowingRecordId);
            if (BorrowingRecord != null) { return BorrowingRecord; }
            return null;
        }

       

        public async Task<ViewModelForBorrowWithId> UpdateBorrowingRecordById(int BorrowingRecordId, ViewModelForBorrow Model)
        {
            var BorrowingRecord = _dbContext.BorrowingRecords.Include(a=>a.book).FirstOrDefault(b => b.borrowId == BorrowingRecordId);
            var book = _dbContext.Books.FirstOrDefault(b => b.BookID == Model.bookId);
            
            if(BorrowingRecord == null || Model.ReturnDate!=null ? Model.ReturnDate > DateTime.Now : false)
            {
                throw new Exception("not valid!");
            }
            if (BorrowingRecord.ReturnDate != null && BorrowingRecord.ReturnDate < DateTime.Now && Model.ReturnDate == null && CalculateAvailableCopies(book.BookID) < 1)
            {
                throw new Exception("Invalid count: Active borrow records exceed total copies available.");
            }

            BorrowingRecord.BorrowDate=Model.BorrowDate.Value;
            BorrowingRecord.ReturnDate=Model.ReturnDate;
            BorrowingRecord.borrowerAddress = Model.borrowerAddress;
            BorrowingRecord.borrowerName = Model.borrowerName;
            BorrowingRecord.phoneNumber = Model.phoneNumber;
            BorrowingRecord.bookId =Model.bookId; 
            _dbContext.BorrowingRecords.Update(BorrowingRecord);
            _dbContext.SaveChanges();
            var BorrowingRecordReturn = _dbContext.BorrowingRecords.Select(a => new ViewModelForBorrowWithId
            {
                borrowId = a.borrowId,
                bookId = a.bookId,
                borrowerAddress = a.borrowerAddress,
                borrowerName = a.borrowerName,
                phoneNumber = a.phoneNumber,
                BorrowDate = a.BorrowDate,
                ReturnDate = a.ReturnDate
            }).FirstOrDefault(b => b.borrowId == BorrowingRecordId);
            return BorrowingRecordReturn;
            
        }
        public int CalculateAvailableCopies(int bookId)
        {
            var book = _dbContext.Books.Include(b => b.BorrowingRecords).SingleOrDefault(b => b.BookID == bookId);

            if (book == null || book.TotalCopies == null)
                return 0;

            int activeLoans = book.BorrowingRecords?.Count(br => br.ReturnDate == null || br.ReturnDate > DateTime.Now) ?? 0;
            return book.TotalCopies.Value - activeLoans;
        }
        public int CountActiveBorrowRecords(int bookId)
        {
            var book = _dbContext.Books.Include(b => b.BorrowingRecords).SingleOrDefault(b => b.BookID == bookId);

            if (book == null)
                return 0;

            return book.BorrowingRecords?.Count(br => br.ReturnDate == null || br.ReturnDate > DateTime.Now) ?? 0;
        }

    }
}
