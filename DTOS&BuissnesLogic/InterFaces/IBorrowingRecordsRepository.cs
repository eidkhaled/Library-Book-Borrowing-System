using DataBase;
using DTOS_BuissnesLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS_BuissnesLogic.InterFaces
{
    public interface IBorrowingRecordsRepository
    {
        Task<ViewModelForBorrow> AddNewBorrowingRecord(ViewModelForBorrow Model);
        Task<ViewModelForBorrowWithId> GetBorrowingRecordById(int BorrowingRecordId);
        Task<IEnumerable<ViewModelForBorrowWithId>> GetAllBorrowingRecords();
        Task<ViewModelForBorrowWithId> UpdateBorrowingRecordById(int BorrowingRecordId, ViewModelForBorrow Model);
/*        Task<bool> DeleteBorrowingRecordById(int BorrowingRecordId);
*/    }
}
