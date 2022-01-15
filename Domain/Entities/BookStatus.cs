using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookStatus : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();
    }
}
