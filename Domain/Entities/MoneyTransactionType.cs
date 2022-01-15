using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MoneyTransactionType : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<MoneyTransaction> MoneyTransactions { get; set; } = new List<MoneyTransaction>();
    }
}
