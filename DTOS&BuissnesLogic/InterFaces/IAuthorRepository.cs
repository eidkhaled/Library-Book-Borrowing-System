using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS_BuissnesLogic.InterFaces
{
    public interface IAuthorRepository
    {
        Task<Author> AddNewAuthor(Author Model);
        Task<Author> GetAuthorById(int AuthorId);
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> UpdateAuthorById(int AuthorId, Author Model);
        Task<bool> DeleteAuthorById(int AuthorId);
    }
}
