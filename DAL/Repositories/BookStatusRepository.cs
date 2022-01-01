using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class BookStatusRepository : Repository<BookStatus>
    {
        public BookStatusRepository(LibraryContext context) : base(context)
        {
        }
        public override async Task<ICollection<BookStatus>> GetAllAsync()
        {
            return await Context.BookStatuses
                .Include(e => e.BookCopies)
                .ToListAsync();
        }

        public override async Task<ICollection<BookStatus>> GetByFilterAsync(Expression<Func<BookStatus, bool>> expression)
        {
            return await Context.BookStatuses
                .Where(expression)
                .Include(e => e.BookCopies)
                .ToListAsync();
        }

        public override async Task<BookStatus> GetByIdAsync(int id)
        {
            return await Context.BookStatuses
                .Include(e => e.BookCopies)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
