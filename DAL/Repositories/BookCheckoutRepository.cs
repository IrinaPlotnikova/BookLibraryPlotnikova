using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BookCheckoutRepository : Repository<BookCheckout>
    {
        public BookCheckoutRepository(LibraryContext context) : base(context)
        {
        }

        public override async Task<ICollection<BookCheckout>> GetAllAsync()
        {
            return await Context.BookCheckouts
                .Include(e => e.BookCopy).ThenInclude(bc => bc.Book)
                .Include(e => e.Reader)
                .ToListAsync();
        }

        public override async Task<ICollection<BookCheckout>> GetByFilterAsync(Expression<Func<BookCheckout, bool>> expression)
        {
            return await Context.BookCheckouts
                .Include(e => e.BookCopy).ThenInclude(bc => bc.Book)
                .Include(e => e.Reader)
                .Where(expression)
                .ToListAsync();
        }

        public override async Task<BookCheckout> GetByIdAsync(int id)
        {
            return await Context.BookCheckouts
                .Include(e => e.BookCopy).ThenInclude(bc => bc.Book)
                .Include(e => e.Reader)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
