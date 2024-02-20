using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS_BuissnesLogic.InterFaces
{
    public interface IBorrowingRecordsRepository
    {
        Task<BorrowingRecords> AddNewBorrowingRecord(BorrowingRecords Model);
        Task<BorrowingRecords> GetBorrowingRecordById(int BorrowingRecordId);
        Task<IEnumerable<BorrowingRecords>> GetAllBorrowingRecords();
        Task<BorrowingRecords> UpdateBorrowingRecordById(int BorrowingRecordId, BorrowingRecords Model);
        Task<bool> DeleteBorrowingRecordById(int BorrowingRecordId);
    }
}
