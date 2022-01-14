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
    public class CountryRepository : Repository<Country>
    {
        public CountryRepository(LibraryContext context) : base(context)
        {
        }
        public override async Task<ICollection<Country>> GetAllAsync()
        {
            return await Context.Countries
                .Include(e => e.Authors)
                .ToListAsync();
        }

        public override async Task<ICollection<Country>> GetByFilterAsync(Expression<Func<Country, bool>> expression)
        {
            return await Context.Countries
                .Include(e => e.Authors)
                .Where(expression)
                .ToListAsync();
        }

        public override async Task<Country> GetByIdAsync(int id)
        {
            return await Context.Countries
                .Include(e => e.Authors)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
