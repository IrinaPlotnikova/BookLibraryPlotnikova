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
    public class MoneyTransactionTypeRepository : Repository<MoneyTransactionType>
    {
        public MoneyTransactionTypeRepository(LibraryContext context) : base(context)
        {
        }
        public override async Task<ICollection<MoneyTransactionType>> GetAllAsync()
        {
            return await Context.MoneyTransactionTypes
                .Include(e => e.MoneyTransactions)
                .ToListAsync();
        }

        public override async Task<ICollection<MoneyTransactionType>> GetByFilterAsync(Expression<Func<MoneyTransactionType, bool>> expression)
        {
            return await Context.MoneyTransactionTypes
                .Where(expression)
                .Include(e => e.MoneyTransactions)
                .ToListAsync();
        }

        public override async Task<MoneyTransactionType> GetByIdAsync(int id)
        {
            return await Context.MoneyTransactionTypes
                .Include(e => e.MoneyTransactions)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
