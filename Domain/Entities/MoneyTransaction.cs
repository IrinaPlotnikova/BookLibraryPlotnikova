using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MoneyTransaction : IBaseEntity
    {
        public int Id { get; set; }

        public int AmountOfMoney { get; set; }

        public DateTime Date { get; set; }

        public int? MoneyTransactionTypeId { get; set; }

        public MoneyTransactionType MoneyTransactionType { get; set; }

        public int? BookCopyId { get; set; }

        public BookCopy BookCopy { get; set; }

        public int? ReaderId { get; set; }

        public Reader Reader { get; set; }
    }
}
