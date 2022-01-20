using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMoneyTransactionTypeService
    {
           public Task CreateMoneyTransactionTypes(IEnumerable<MoneyTransactionType> moneyTransactionTypes);

           public Task DeleteAll();
    }
}
