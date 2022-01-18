using BLL.Filters;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMoneyTransactionService
    {
        public Task CreateMoneyTransaction(MoneyTransaction moneyTransaction);

        public Task CreateMoneyTransactions(IEnumerable<MoneyTransaction> moneyTransactions);

        public Task<ICollection<MoneyTransaction>> GetTransactionsByDates(DateFilter filter);

        public Task DeleteAll();

        public Task<MemoryStream> SaveStatisticsAsXlsxFileToMemoryStream(DateFilter filter);
    }
}
