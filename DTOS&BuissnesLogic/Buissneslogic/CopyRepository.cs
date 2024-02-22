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
    public class CopyRepository:IBookCopyRepository
    {
        private AppDbContext _dbContext;
        public CopyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public async Task<ViewModelForCopiesForAdd> AddNewBookCopy(ViewModelForCopiesForAdd Model)
        {
            if (Model == null) return null;
            BookCopy bookCopy = new BookCopy()
            {
                BookID=Model.BookID,
                NumberOfCopies=Model.NumberOfCopies,
               
                
            };
            if (bookCopy.NumberOfCopies == 0)
            {
                bookCopy.Status=StatusAvailable.NotAvailable.ToString();
            }
            await _dbContext.BookCopies.AddAsync(bookCopy);
            await _dbContext.SaveChangesAsync();
            
            

            return Model;
        }

      
        public async Task<bool> DeleteBookCopiesById(int CopyId)
        {
            var Copy = _dbContext.BookCopies.FirstOrDefault(b => b.CopyId == CopyId);
            if (Copy != null)
            {
                _dbContext.BookCopies.Remove(Copy);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<BookCopy>> GetAllBooksCopy()
        {
            var Copies = await _dbContext.BookCopies.Include(a=>a.Book).ToListAsync();
            return Copies;
        }

       
        public async Task<BookCopy> GetBookCopyById(int CopyId)
        {
            var Copy = _dbContext.BookCopies.FirstOrDefault(b => b.CopyId== CopyId);
            if (Copy != null) { return Copy; }
            return null;
        }

        
        public async Task<BookCopy> UpdateBookCopyiesById(int CopyId, ViewModelForCopiesForAdd Model)
        {
            var BookCopy = _dbContext.BookCopies.FirstOrDefault(b => b.CopyId == CopyId);
            if (BookCopy != null)
            {
                BookCopy.NumberOfCopies = Model.NumberOfCopies;
                if (Model.NumberOfCopies > 0) { BookCopy.Status =StatusAvailable.Available.ToString(); }
                else {  BookCopy.Status =StatusAvailable.NotAvailable.ToString(); }

                _dbContext.BookCopies.Update(BookCopy);
                await _dbContext.SaveChangesAsync();
                return BookCopy;
            }
            return null;
        }
    }
    }

