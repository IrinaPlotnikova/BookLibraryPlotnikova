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
    public class PublisherRepository : Repository<Publisher>
    {
        public PublisherRepository(LibraryContext context) : base(context)
        {
        }


        public override async Task<ICollection<Publisher>> GetAllAsync()
        {
            return await Context.Publishers
                .Include(e => e.Country)
                .Include(e => e.Books)
                .ToListAsync();
        }

        public override async Task<ICollection<Publisher>> GetByFilterAsync(Expression<Func<Publisher, bool>> expression)
        {
            return await Context.Publishers
                .Include(e => e.Country)
                .Include(e => e.Books)
                .Where(expression)
                .ToListAsync();
        }

        public override async Task<Publisher> GetByIdAsync(int id)
        {
            return await Context.Publishers
                .Include(e => e.Country)
                .Include(e => e.Books)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
