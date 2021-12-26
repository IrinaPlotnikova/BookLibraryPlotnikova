using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MoneyTransaction : BaseEntity
    {
        public int AmountOfMoney { get; set; }

        public DateTime Date { get; set; }

        public int MoneyTransactionTypeId { get; set; }

        public MoneyTransactionType MoneyTransactionType { get; set; }

        public int BookCheckoutId { get; set; }

        public BookCheckout BookCheckout { get; set; }
    }
}
