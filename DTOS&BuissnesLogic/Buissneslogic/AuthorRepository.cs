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
    public class AuthorRepository : IAuthorRepository
    {
        private AppDbContext _dbContext;
        public AuthorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> AddNewAuthor(Author Model)
        {
            if (Model == null) return null;
            await _dbContext.Authors.AddAsync(Model);
            await _dbContext.SaveChangesAsync();
            return Model;
        }



        public async Task<bool> DeleteAuthorById(int AuthorId)
        {
            var author = _dbContext.Authors.FirstOrDefault(b => b.AuthorId == AuthorId);
            if (author != null)
            {
                _dbContext.Authors.Remove(author);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }



        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            var Authors = await _dbContext.Authors.ToListAsync();
            return Authors;
        }



        public async Task<Author> GetAuthorById(int AuthorId)
        {
            var Author = _dbContext.Authors.FirstOrDefault(b => b.AuthorId == AuthorId);
            if (Author != null) { return Author; }
            return null;
        }



        public async Task<Author> UpdateAuthorById(int AuthorId, Author Model)
        {
            var Author = _dbContext.Authors.FirstOrDefault(b => b.AuthorId == AuthorId);
            if (Author != null)
            {
                Author.AuthorName = Model.AuthorName;
                Author.AuthorBio = Model.AuthorBio;
                _dbContext.Authors.Update(Author);
                await _dbContext.SaveChangesAsync();
                return Author;
            }
            return null;
        }

    }
}

