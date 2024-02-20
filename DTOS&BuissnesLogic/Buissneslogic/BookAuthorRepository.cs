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
    public class BookAuthorRepository:IBookAuthorRepository
    {
        private AppDbContext _dbContext;
        public BookAuthorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookAuthor> AddNewBookAuthor(BookAuthor Model)
        {
            if (Model == null) return null;
            
            await _dbContext.BookAuthors.AddAsync(Model);

            await _dbContext.SaveChangesAsync();
            return Model;
        }

       

        public async Task<bool> DeleteBookAuthorById(int BookId, int AuthorId)
        {
            var BookAuthor = _dbContext.BookAuthors.FirstOrDefault(b => b.BookId == BookId&&b.AuthorId==AuthorId);
            if (BookAuthor != null)
            {
                _dbContext.BookAuthors.Remove(BookAuthor);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        

        public async Task<IEnumerable<BookAuthor>> GetAllBookAuthors()
        {
            var BookAuthors = await _dbContext.BookAuthors.ToListAsync();
            return BookAuthors;
        }

        

        public async Task<BookAuthor> GetBookAuthorById(int BookId, int AuthorId)
        {
            var BookAuthor = _dbContext.BookAuthors.FirstOrDefault(b => b.BookId == BookId && b.AuthorId == AuthorId);
            if (BookAuthor != null)
            {
                return BookAuthor;
            }
            return null;
        }

        
        public async Task<BookAuthor> UpdateBookAuthorById(int BookId, int AuthorId, BookAuthor Model)
        {
            var BookAuthor = _dbContext.BookAuthors.FirstOrDefault(b => b.BookId == BookId && b.AuthorId == AuthorId);
            if (BookAuthor != null)
            {

                BookAuthor.AuthorId=Model.AuthorId;
                BookAuthor.BookId=Model.BookId;
                _dbContext.BookAuthors.Update(BookAuthor);
                _dbContext.SaveChanges();
                return BookAuthor;

            }
            return null;
        }

        

    }
}
