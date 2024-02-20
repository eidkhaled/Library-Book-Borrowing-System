using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS_BuissnesLogic.InterFaces
{
    public interface IBookAuthorRepository
    {
        Task<BookAuthor> AddNewBookAuthor(BookAuthor Model);
        Task<BookAuthor> GetBookAuthorById(int BookId,int AuthorId);
        Task<IEnumerable<BookAuthor>> GetAllBookAuthors();
        Task<BookAuthor> UpdateBookAuthorById(int BookId, int AuthorId, BookAuthor Model);
        Task<bool> DeleteBookAuthorById(int BookId, int AuthorId);
    }
}
