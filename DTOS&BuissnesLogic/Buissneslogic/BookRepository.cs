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
 
    public class BookRepository:IBookRepository
    {
        private AppDbContext _dbContext;
        public BookRepository(AppDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public async Task<viewModelForBook> AddNewBook(viewModelForBook Model)
        {
            //if (Model == null) return null;
            Book book = new Book()
            {

                Description = Model.Description,
                ISBN = Model.ISBN,
                Title = Model.Title,
                PublicationYear = Model.PublicationYear
                
            };
              _dbContext.Books.AddAsync(book);
             await _dbContext.SaveChangesAsync();
            return Model;
       }    
        public async Task<Book?> GetBookById(int BookId)
        {
            var Book= _dbContext.Books.FirstOrDefault(a=>a.BookID==BookId);
            return Book;

        }
        
        public async Task<List<viewModelForBook>> GetAllBooks()
        {
            
            var Books = await _dbContext.Books.
                Select(a => new viewModelForBook {BookID=a.BookID,CategoryID=a.CategoryId,CategoryName= a.Category != null ? a.Category.CategoryName : null, Title =a.Title, Description = a.Description, ISBN = a.ISBN , PublicationYear=a.PublicationYear }).
                ToListAsync();
            
            return Books;
        }
        
        public async Task<viewModelForBook> UpdateBookById(int BookId, viewModelForBook Model)
        {
            var book=  _dbContext.Books.FirstOrDefault(b=>b.BookID==BookId);
            book.ISBN=Model.ISBN;
            
            book.Description=Model.Description;
            book.Title=Model.Title;
            book.CategoryId=Model.CategoryID;
             _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
            return Model;
        }

        public async Task<bool> DeleteBookById(int BookId)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.BookID == BookId);
            if (book==null)  return false;
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
