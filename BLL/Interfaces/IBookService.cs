using BLL.Filters;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBookService
    {
        public Task AddBook(Book book);

        public Task UpdateBook(Book book);

        public Task<Book> DeleteBook(int bookId);

        public Task<ICollection<Book>> GetAllBooks();

        public Task<Book> GetBookById(int bookId);

        public Task<ICollection<Book>> GetAvailableBooks();

        public Task<ICollection<Book>> GetBooksByGenresAuthorsAndPublishersId(BookFilter bookFilter);

        public Task<ICollection<Book>> GetBooksByName(string name);
    }
}
