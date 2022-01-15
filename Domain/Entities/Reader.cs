using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reader : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Passport { get; set; }

        public ICollection<BookCheckout> BookCheckouts { get; set; } = new List<BookCheckout>();

        public ICollection<MoneyTransaction> MoneyTransactions { get; set; } = new List<MoneyTransaction>();

        public ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();
    }
}
