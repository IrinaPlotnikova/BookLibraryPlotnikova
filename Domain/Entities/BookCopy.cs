using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookCopy : IBaseEntity
    {
        public int Id { get; set; }

        public int? BookId { get; set; }

        public Book Book { get; set; }

        public int? BookStatusId { get; set; }

        public BookStatus BookStatus { get; set; }

        public int? ReaderId { get; set; }

        public Reader Reader { get; set; }

        public ICollection<BookCheckout> BookCheckouts { get; set; } = new List<BookCheckout>();

        public ICollection<MoneyTransaction> MoneyTransactions { get; set; } = new List<MoneyTransaction>();
    }
}

