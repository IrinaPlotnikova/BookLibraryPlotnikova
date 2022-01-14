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
    public class GenreRepository : Repository<Genre>
    {
        public GenreRepository(LibraryContext context) : base(context)
        {
        }
        public override async Task<ICollection<Genre>> GetAllAsync()
        {
            return await Context.Genres
                .Include(e => e.Books)
                .ToListAsync();
        }

        public override async Task<ICollection<Genre>> GetByFilterAsync(Expression<Func<Genre, bool>> expression)
        {
            return await Context.Genres
                .Include(e => e.Books)
                .Where(expression)
                .ToListAsync();
        }

        public override async Task<Genre> GetByIdAsync(int id)
        {
            return await Context.Genres
                .Include(e => e.Books)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
