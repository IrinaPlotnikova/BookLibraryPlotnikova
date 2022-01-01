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
    public class MoneyTransactionRepository : Repository<MoneyTransaction>
    {
        public MoneyTransactionRepository(LibraryContext context) : base(context)
        {
        }
        public override async Task<ICollection<MoneyTransaction>> GetAllAsync()
        {
            return await Context.MoneyTransactions
                .Include(e => e.BookCheckout)
                .Include(e => e.MoneyTransactionType)
                .ToListAsync();
        }

        public override async Task<ICollection<MoneyTransaction>> GetByFilterAsync(Expression<Func<MoneyTransaction, bool>> expression)
        {
            return await Context.MoneyTransactions
                .Where(expression)
                .Include(e => e.BookCheckout)
                .Include(e => e.MoneyTransactionType)
                .ToListAsync();
        }

        public override async Task<MoneyTransaction> GetByIdAsync(int id)
        {
            return await Context.MoneyTransactions
                .Include(e => e.BookCheckout)
                .Include(e => e.MoneyTransactionType)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
