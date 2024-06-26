﻿using DataBase;
using DTOS_BuissnesLogic.DTOs;
using DTOS_BuissnesLogic.InterFaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                PublicationYear = Model.PublicationYear,
                TotalCopies = Model.TotalCopies,
                CategoryId = Model.CategoryId
                
            };
              _dbContext.Books.AddAsync(book);
             await _dbContext.SaveChangesAsync();
            Model.BookID = book.BookID;
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
                Select(a => new viewModelForBook {
                    BookID=a.BookID,
                    CategoryId = a.CategoryId,
                    CategoryName= a.Category != null ? a.Category.CategoryName : null,
                    Title =a.Title,
                    Description = a.Description,
                    ISBN = a.ISBN ,
                    TotalCopies=a.TotalCopies,
                    PublicationYear=a.PublicationYear ,
                    AvailbleCopies = a.TotalCopies - a.BorrowingRecords.Count(br => br.ReturnDate == null || br.ReturnDate > DateTime.Now),
                    ActiveCopies = a.BorrowingRecords.Count(br => br.ReturnDate == null || br.ReturnDate > DateTime.Now)

                }).
                ToListAsync();
            
            return Books;
        }
        
        public async Task<viewModelForBook> UpdateBookById(int BookId, viewModelForBook Model)
        {

            var book=  _dbContext.Books.FirstOrDefault(b=>b.BookID==BookId);
            var active = CountActiveBorrowRecords(BookId);
            if (active != 0 && (Model.TotalCopies - active <0))
            {
                throw new Exception("Invalid count: Active borrow records exceed total copies available.");
            }
            book.ISBN=Model.ISBN;
            book.Description=Model.Description;
            book.Title=Model.Title;
            book.CategoryId=Model.CategoryId;
            book.TotalCopies=Model.TotalCopies;
             _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();

            Model.ActiveCopies = book.TotalCopies - book.BorrowingRecords.Count(br => br.ReturnDate == null || br.ReturnDate > DateTime.Now);
            Model.AvailbleCopies = book.BorrowingRecords.Count(br => br.ReturnDate == null || br.ReturnDate > DateTime.Now);
            return Model;
        }

        public async Task<bool> DeleteBookById(int BookId)
        {
            var book = _dbContext.Books.Include(x=>x.BorrowingRecords).FirstOrDefault(b => b.BookID == BookId);
            if (book==null || book.BorrowingRecords.Count>0)  return false;

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    

        public int CountActiveBorrowRecords(int bookId)
        {
            var book = _dbContext.Books.Include(b => b.BorrowingRecords).SingleOrDefault(b => b.BookID == bookId);

            if (book == null)
                return 0;

            return book.BorrowingRecords?.Count(br => br.ReturnDate == null || br.ReturnDate > DateTime.Now) ?? 0;
        }
    }
}
