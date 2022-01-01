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
    public class AuthorRepository : Repository<Author>
    {
        public AuthorRepository(LibraryContext context) : base(context)
        {
        }

        public override async Task<ICollection<Author>> GetAllAsync()
        {
            return await Context.Authors
                .Include(e => e.Country)
                .Include(e => e.BookAuthors)
                .ToListAsync();
        }

        public override async Task<ICollection<Author>> GetByFilterAsync(Expression<Func<Author, bool>> expression)
        {
            return await Context.Authors
                .Where(expression)
                .Include(e => e.Country)
                .Include(e => e.BookAuthors)
                .ToListAsync();
        }

        public override async Task<Author> GetByIdAsync(int id)
        {
            return await Context.Authors
                .Include(e => e.Country)
                .Include(e => e.BookAuthors)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

    }
}
