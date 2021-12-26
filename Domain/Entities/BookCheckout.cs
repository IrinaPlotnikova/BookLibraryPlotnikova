using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookCheckout : BaseEntity
    {
        public int BookCopyId { get; set; }

        public BookCopy BookCopy { get; set; }

        public int ReaderId { get; set; }

        public Reader Reader { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateFinish { get; set; }

        public DateTime DateBookReturned { get; set; }

        public int LostBookFine { get; set; }

        public int OverdueFine { get; set; }

        public ICollection<MoneyTransaction> MoneyTransactions { get; set; } = new List<MoneyTransaction>();

    }
}
