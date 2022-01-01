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
    public class BookAuthorRepository : Repository<BookAuthor>
    {
        public BookAuthorRepository(LibraryContext context) : base(context)
        {
        }

        public override async Task<ICollection<BookAuthor>> GetAllAsync()
        {
            return await Context.BookAuthors
                .Include(e => e.Book)
                .Include(e => e.Author)
                .ToListAsync();
        }

        public override async Task<ICollection<BookAuthor>> GetByFilterAsync(Expression<Func<BookAuthor, bool>> expression)
        {
            return await Context.BookAuthors
                .Where(expression)
                .Include(e => e.Book)
                .Include(e => e.Author)
                .ToListAsync();
        }

        public override async Task<BookAuthor> GetByIdAsync(int id)
        {
            return await Context.BookAuthors
                .Include(e => e.Book)
                .Include(e => e.Author)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
