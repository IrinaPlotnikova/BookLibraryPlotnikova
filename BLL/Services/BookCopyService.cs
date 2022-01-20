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
    public class BookCopyService : IBookCopyService
    {

        private readonly IRepository<BookCopy> repository;

        public BookCopyService(IRepository<BookCopy> repository)
        {
            this.repository = repository;
        }

        public Task CreateBookCopy(BookCopy bookCopy)
        {
            return repository.CreateAsync(bookCopy);
        }

        public Task<ICollection<BookCopy>> GetAvailableCopiesByBookId(int bookId)
        {
            Expression<Func<BookCopy, bool>> expression = e => e.BookId == bookId && e.ReaderId == null;
            return repository.GetByFilterAsync(expression);
        }

        public Task UpdateBookCopy(BookCopy bookCopy)
        {
            return repository.UpdateItemAsync(bookCopy);
        }

        public Task CreateBookCopies(IEnumerable<BookCopy> bookCopies)
        {
            return repository.CreateRangeAsync(bookCopies);
        }

        public Task DeleteAll()
        {
            return repository.Clear();
        }
    }
}
