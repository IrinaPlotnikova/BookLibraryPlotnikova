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
    public class ReaderRepository : Repository<Reader>
    {
        public ReaderRepository(LibraryContext context) : base(context)
        {
        }
        public override async Task<ICollection<Reader>> GetAllAsync()
        {
            return await Context.Readers
                .Include(e => e.BookCheckouts).ThenInclude(bc =>bc.BookCopy).ThenInclude(copy => copy.Book)
                .Include(e => e.MoneyTransactions)
                .Include(e => e.BookCopies).ThenInclude(bc =>bc.Book)
                .ToListAsync();
        }

        public override async Task<ICollection<Reader>> GetByFilterAsync(Expression<Func<Reader, bool>> expression)
        {
            return await Context.Readers
                .Include(e => e.BookCheckouts).ThenInclude(bc =>bc.BookCopy).ThenInclude(copy => copy.Book)
                .Include(e => e.MoneyTransactions)
                .Include(e => e.BookCopies).ThenInclude(bc =>bc.Book)
                .Where(expression)
                .ToListAsync();
        }

        public override async Task<Reader> GetByIdAsync(int id)
        {
            return await Context.Readers
                .Include(e => e.BookCheckouts).ThenInclude(bc =>bc.BookCopy).ThenInclude(copy => copy.Book)
                .Include(e => e.MoneyTransactions)
                .Include(e => e.BookCopies).ThenInclude(bc =>bc.Book)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
