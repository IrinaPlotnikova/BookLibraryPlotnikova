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
    public class BookService : IBookService
    {
        private readonly IRepository<Book> repository;

        public BookService(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        public Task CreateBook(Book book)
        {
            return repository.CreateAsync(book);
        }

        public Task<Book> DeleteBook(int bookId)
        {
            return repository.DeleteItemAsync(bookId);
        }

        public Task<ICollection<Book>> GetAllBooks()
        {
            return repository.GetAllAsync();  
        }

        public Task<Book> GetBookById(int bookId)
        {
            return repository.GetByIdAsync(bookId);
        }

        public Task UpdateBook(Book book)
        {
            return repository.UpdateItemAsync(book);
        }

        public Task<ICollection<Book>> GetAvailableBooks()
        {
            Expression<Func<Book, bool>> expression = e => e.BookCopies.Where(p => p.BookStatusId == 1).Count() != 0;
            return repository.GetByFilterAsync(expression);
        }

        public Task<ICollection<Book>> GetBooksByGenresAuthorsAndPublishersId(BookFilter bookFilter)
        {
            bool isGenresIdEmpty = bookFilter.GenresId.Count() == 0;
            bool isAuthorsIdEmpty = bookFilter.AuthorsId.Count() == 0;
            bool isPublishersIdEmpty = bookFilter.PublishersId.Count() == 0;
            IEnumerable<int> authorsId = bookFilter.AuthorsId;
            
            Expression<Func<Book, bool>> expression = e => (isGenresIdEmpty || bookFilter.GenresId.Contains(e.GenreId)) &&
                                                           (isPublishersIdEmpty || bookFilter.PublishersId.Contains(e.PublisherId)) &&
                                                           (isAuthorsIdEmpty || e.Authors.Select(j => j.Id).Any(id => authorsId.Contains(id)));
             
            return repository.GetByFilterAsync(expression);
        }

        public Task<ICollection<Book>> GetBooksByName(string name)
        {
            Expression<Func<Book, bool>> expression = e => e.Name == name;
            return repository.GetByFilterAsync(expression);
        }

        public Task CreateBooks(IEnumerable<Book> books)
        {
            return repository.CreateRangeAsync(books);
        }

        public Task DeleteAll()
        {
            return repository.Clear();
        }
    }
}
