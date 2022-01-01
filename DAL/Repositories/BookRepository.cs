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
    public class BookRepository : Repository<Book>
    {
        public BookRepository(LibraryContext context) : base(context)
        {
        }
        public override async Task<ICollection<Book>> GetAllAsync()
        {
            return await Context.Books
                .Include(e => e.Genre)
                .Include(e => e.Publisher)
                .Include(e => e.Authors)
                .Include(e => e.BookCopies)
                .ToListAsync();
        }

        public override async Task<ICollection<Book>> GetByFilterAsync(Expression<Func<Book, bool>> expression)
        {
            return await Context.Books
                .Where(expression)
                .Include(e => e.Genre)
                .Include(e => e.Publisher)
                .Include(e => e.Authors)
                .Include(e => e.BookCopies)
                .ToListAsync();
        }

        public override async Task<Book> GetByIdAsync(int id)
        {
            return await Context.Books
                .Include(e => e.Genre)
                .Include(e => e.Publisher)
                .Include(e => e.Authors)
                .Include(e => e.BookCopies)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
