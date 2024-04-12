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
            //Model.bookCopy.NumberOfCopies -= 1;
            var a=_dbContext.BookCopies.FirstOrDefault(a => a.CopyId == Model.bookCopyId);
            if (a.NumberOfCopies >= 1)
            {
                BorrowingRecords borrowingRecords = new BorrowingRecords()
                {
                    bookCopyId = Model.bookCopyId,
                    BorrowDate = DateTime.Now,
                    DueDate = DateTime.Now,
                    ReturnDate = Model.ReturnDate,
                };
                await _dbContext.BorrowingRecords.AddAsync(borrowingRecords);
                a.NumberOfCopies -= 1;
                if (a.NumberOfCopies == 0) { a.Status = StatusAvailable.NotAvailable.ToString(); }
                await _dbContext.SaveChangesAsync();
                return Model;

            }
            return null;
            
        }

        

        public async Task<bool> DeleteBorrowingRecordById(int BorrowingRecordId)
        {
            var BorrowRecord = _dbContext.BorrowingRecords.FirstOrDefault(b => b.BorrowId== BorrowingRecordId);
            if (BorrowRecord != null)
            {
                _dbContext.BorrowingRecords.Remove(BorrowRecord);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        

        public async Task<IEnumerable<ViewModelForBorrowWithId>> GetAllBorrowingRecords()
        {
            var BorrowingRecords = await _dbContext.BorrowingRecords.
                Select(a=>new ViewModelForBorrowWithId
                {
                    BorrowId = a.BorrowId,
                    bookCopyId = a.bookCopyId,
                    BorrowDate = a.BorrowDate,
                    DueDate = a.DueDate,
                    ReturnDate = a.ReturnDate
                }).ToListAsync();
            return BorrowingRecords;
        }

        
        public async Task<ViewModelForBorrowWithId> GetBorrowingRecordById(int BorrowingRecordId)
        {
            var BorrowingRecord = _dbContext.BorrowingRecords.Select(a=>new ViewModelForBorrowWithId
            {BorrowId=a.BorrowId, bookCopyId = a.bookCopyId, BorrowDate = a.BorrowDate,
                DueDate = a.DueDate, ReturnDate = a.ReturnDate }).FirstOrDefault(b => b.BorrowId == BorrowingRecordId);
            if (BorrowingRecord != null) { return BorrowingRecord; }
            return null;
        }

       

        public async Task<ViewModelForBorrowWithId> UpdateBorrowingRecordById(int BorrowingRecordId, ViewModelForBorrow Model)
        {
            var BorrowingRecord = _dbContext.BorrowingRecords.Include(a=>a.bookCopy).FirstOrDefault(b => b.BorrowId == BorrowingRecordId);
            var NofBorrows = _dbContext.BookCopies./*Include(a=>a.bookCopy).*/FirstOrDefault(b => b.CopyId == Model.bookCopyId);
            
            if (BorrowingRecord != null&& NofBorrows.NumberOfCopies >= 1)
            {

                BorrowingRecord.BorrowDate=Model.BorrowDate;
                BorrowingRecord.DueDate=Model.DueDate;
                BorrowingRecord.ReturnDate=Model.ReturnDate;
                BorrowingRecord.bookCopyId=Model.bookCopyId; 
                _dbContext.BorrowingRecords.Update(BorrowingRecord);
                _dbContext.SaveChanges();
                var BorrowingRecordReturn = _dbContext.BorrowingRecords.Select(a => new ViewModelForBorrowWithId
                {
                    BorrowId = a.BorrowId,
                    bookCopyId = a.bookCopyId,
                    BorrowDate = a.BorrowDate,
                    DueDate = a.DueDate,
                    ReturnDate = a.ReturnDate
                }).FirstOrDefault(b => b.BorrowId == BorrowingRecordId);
                return BorrowingRecordReturn;

            }
            return null;
        }

        
    }
}
