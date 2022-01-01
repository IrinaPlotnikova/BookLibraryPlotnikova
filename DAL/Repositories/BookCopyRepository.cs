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
    public class BookCopyRepository : Repository<BookCopy>
    {
        public BookCopyRepository(LibraryContext context) : base(context)
        {
        }

        public override async Task<ICollection<BookCopy>> GetAllAsync()
        {
            return await Context.BookCopies
                .Include(e => e.Book)
                .Include(e => e.BookStatus)
                .Include(e => e.BookCheckouts)
                .ToListAsync();
        }

        public override async Task<ICollection<BookCopy>> GetByFilterAsync(Expression<Func<BookCopy, bool>> expression)
        {
            return await Context.BookCopies
                .Where(expression)
                .Include(e => e.Book)
                .Include(e => e.BookStatus)
                .Include(e => e.BookCheckouts)
                .ToListAsync();
        }

        public override async Task<BookCopy> GetByIdAsync(int id)
        {
            return await Context.BookCopies
                .Include(e => e.Book)
                .Include(e => e.BookStatus)
                .Include(e => e.BookCheckouts)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
