using BLL.Interfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MoneyTransactionTypeService : IMoneyTransactionTypeService
    {
        private readonly IRepository<MoneyTransactionType> repository;

        public MoneyTransactionTypeService(IRepository<MoneyTransactionType> repository)
        {
            this.repository = repository;
        }
        public Task CreateMoneyTransactionTypes(IEnumerable<MoneyTransactionType> moneyTransactionTypes)
        {
            return repository.CreateRangeAsync(moneyTransactionTypes);
        }

        public Task DeleteAll()
        {
            return repository.Clear();
        }
    }
}
