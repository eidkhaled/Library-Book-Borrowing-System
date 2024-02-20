using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS_BuissnesLogic.InterFaces
{
    public interface IBookCopyRepository
    {
        Task<BookCopy> AddNewBookCopy(BookCopy Model);
        Task<BookCopy> GetBookCopyById(int BookId);
        Task<IEnumerable<BookCopy>> GetAllBooksCopy();
        //Grouping for id => nOf Copies
        Task<BookCopy> UpdateBookCopyiesById(int BookId, BookCopy Model);
        Task<bool> DeleteBookCopiesById(int BookId);
    }
}
