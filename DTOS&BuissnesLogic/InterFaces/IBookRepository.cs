using DataBase;
using DTOS_BuissnesLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS_BuissnesLogic.InterFaces
{
    public interface IBookRepository
    {
        Task<viewModelForBook> AddNewBook(viewModelForBook Model);
        Task<Book> GetBookById(int BookId);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> UpdateBookById(int BookId,Book Model);
        Task<bool> DeleteBookById(int BookId);

    }
}
