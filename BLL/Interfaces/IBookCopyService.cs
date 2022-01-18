using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBookCopyService
    {
        public Task<ICollection<BookCopy>> GetAvailableCopiesByBookId(int bookId);

        public Task CreateBookCopy(BookCopy bookCopy);

        public Task CreateBookCopies(IEnumerable<BookCopy> bookCopies);

        public Task UpdateBookCopy(BookCopy bookCopy);

        public Task DeleteAll();
    }
}
