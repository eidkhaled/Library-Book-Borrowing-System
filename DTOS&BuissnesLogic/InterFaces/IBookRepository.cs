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
        Task<List<viewModelForBook>> GetAllBooks();
        Task<viewModelForBook> UpdateBookById(int BookId, viewModelForBook Model);
        Task<bool> DeleteBookById(int BookId);

    }
}
