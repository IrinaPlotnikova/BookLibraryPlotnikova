using BLL.Filters;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthorService
    {
        public Task AddAuthor(Author author);

        public Task UpdateAuthor(Author author);

        public Task<Author> DeleteAuthor(int authorId);

        public Task<ICollection<Author>> GetAllAuthors();

        public Task<Author> GetAuthorById(int authorId);

        public Task<ICollection<Book>> GetBooksByAuthorId(int countryId);

        public Task<ICollection<Author>> GetAuthorsByCountries(AuthorFilter filter);

        public Task<ICollection<Author>> GetAuthorsById(AuthorFilter filter);

        public Task<ICollection<Author>> GetAuthorsByFullName(string fullName);
    }
}
