using BLL.Filters;
using BLL.Interfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MoneyTransactionService : IMoneyTransactionService
    {
        private readonly IRepository<MoneyTransaction> repository;

        public MoneyTransactionService(IRepository<MoneyTransaction> repository)
        {
            this.repository = repository;
        }

        public Task AddMoneyTransaction(MoneyTransaction moneyTransaction)
        {
            return repository.CreateAsync(moneyTransaction);
        }

        public Task<ICollection<MoneyTransaction>> GetTransactionsByDates(DateFilter filter)
        {
            Expression<Func<MoneyTransaction, bool>> expression = e => filter.FirstDate <= e.Date && e.Date <= filter.LastDate;
            return repository.GetByFilterAsync(expression);
        }

        public Task AddMoneyTransactions(IEnumerable<MoneyTransaction> moneyTransactions)
        {
            return repository.CreateRangeAsync(moneyTransactions);
        }
    }
}
