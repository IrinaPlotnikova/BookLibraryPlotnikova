using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reader : BaseEntity
    {
        public string Name { get; set; }

        public string LibraryCard { get; set; }

        public string Email { get; set; }

        public string Passport { get; set; }

        public ICollection<BookCheckout> BookCheckouts { get; set; } = new List<BookCheckout>();
    }
}
