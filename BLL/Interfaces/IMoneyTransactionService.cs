using BLL.Filters;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMoneyTransactionService
    {
        public Task AddMoneyTransaction(MoneyTransaction bookCopy);

        public Task<ICollection<MoneyTransaction>> GetTransactionsByDates(DateFilter filter);
    }
}
