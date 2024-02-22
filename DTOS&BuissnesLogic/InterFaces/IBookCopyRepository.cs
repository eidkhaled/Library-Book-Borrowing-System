using DataBase;
using DTOS_BuissnesLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS_BuissnesLogic.InterFaces
{
    public interface IBookCopyRepository
    {
        Task<ViewModelForCopiesForAdd> AddNewBookCopy(ViewModelForCopiesForAdd Model);
        Task<BookCopy> GetBookCopyById(int BookId);
        Task<IEnumerable<BookCopy>> GetAllBooksCopy();
        //Grouping for id => nOf Copies
        Task<BookCopy> UpdateBookCopyiesById(int CopyId, ViewModelForCopiesForAdd Model);
        Task<bool> DeleteBookCopiesById(int BookId);
    }
}
