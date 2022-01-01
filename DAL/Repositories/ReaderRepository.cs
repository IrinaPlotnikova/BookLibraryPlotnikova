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
                .Include(e => e.BookCheckouts)
                .ToListAsync();
        }

        public override async Task<ICollection<Reader>> GetByFilterAsync(Expression<Func<Reader, bool>> expression)
        {
            return await Context.Readers
                .Where(expression)
                .Include(e => e.BookCheckouts)
                .ToListAsync();
        }

        public override async Task<Reader> GetByIdAsync(int id)
        {
            return await Context.Readers
                .Include(e => e.BookCheckouts)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
