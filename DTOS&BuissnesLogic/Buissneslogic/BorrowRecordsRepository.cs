using DataBase;
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

        public async Task<BorrowingRecords> AddNewBorrowingRecord(BorrowingRecords Model)
        {
            if (Model == null) return null;
             Model.bookCopy.NumberOfCopies -= 1;
            await _dbContext.BorrowingRecords.AddAsync(Model);
            
            await _dbContext.SaveChangesAsync();
            return Model;
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

        

        public async Task<IEnumerable<BorrowingRecords>> GetAllBorrowingRecords()
        {
            var BorrowingRecords = await _dbContext.BorrowingRecords.ToListAsync();
            return BorrowingRecords;
        }

        
        public async Task<BorrowingRecords> GetBorrowingRecordById(int BorrowingRecordId)
        {
            var BorrowingRecord = _dbContext.BorrowingRecords.FirstOrDefault(b => b.BorrowId == BorrowingRecordId);
            if (BorrowingRecord != null) { return BorrowingRecord; }
            return null;
        }

       

        public async Task<BorrowingRecords> UpdateBorrowingRecordById(int BorrowingRecordId, BorrowingRecords Model)
        {
            var BorrowingRecord = _dbContext.BorrowingRecords.FirstOrDefault(b => b.BorrowId == BorrowingRecordId);
            if (BorrowingRecord != null)
            {

                BorrowingRecord.BorrowDate=Model.BorrowDate;
                BorrowingRecord.DueDate=Model.DueDate;
                BorrowingRecord.ReturnDate=Model.ReturnDate;
                BorrowingRecord.bookCopyId=Model.bookCopyId; 
                _dbContext.BorrowingRecords.Update(BorrowingRecord);
                _dbContext.SaveChanges();
                return BorrowingRecord;

            }
            return null;
        }

        
    }
}
