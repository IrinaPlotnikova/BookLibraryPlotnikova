using BLL.Filters;
using BLL.Interfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> repository;

        public AuthorService(IRepository<Author> repository)
        {
            this.repository = repository;
        }
        public Task CreateAuthor(Author author)
        {
            return repository.CreateAsync(author);
        }

        public Task<Author> DeleteAuthor(int authorId) 
        {
            return repository.DeleteItemAsync(authorId);
        }

        public Task<ICollection<Author>> GetAllAuthors()
        {
            return repository.GetAllAsync();
        }

        public Task<Author> GetAuthorById(int authorId)
        {
            return repository.GetByIdAsync(authorId);
        }

        public async Task<ICollection<Book>> GetBooksByAuthorId(int authorId)
        {
            return (await repository.GetByIdAsync(authorId)).Books;
        }

        public Task UpdateAuthor(Author author)
        {
            return repository.UpdateItemAsync(author);
        }

        public Task<ICollection<Author>> GetAuthorsByCountries(AuthorFilter filter)
        {
            bool isEmpty = filter.CountriesId.Count == 0;
            Expression<Func<Author, bool>> expression = e => isEmpty || filter.CountriesId.Contains(e.CountryId);
            return repository.GetByFilterAsync(expression); 
        }

        public Task<ICollection<Author>> GetAuthorsById(AuthorFilter filter)
        {
            Expression<Func<Author, bool>> expression = e => filter.Ids.Contains(e.Id);
            return repository.GetByFilterAsync(expression);
        }

        public Task<ICollection<Author>> GetAuthorsByFullName(string fullName)
        {
            return repository.GetByFilterAsync(e => e.FullName.ToLower() == fullName.ToLower());
        }

        public Task CreateAuthors(IEnumerable<Author> authors)
        {
            return repository.CreateRangeAsync(authors);
        }

        public Task DeleteAll()
        {
            return repository.Clear();
        }
    }
}
