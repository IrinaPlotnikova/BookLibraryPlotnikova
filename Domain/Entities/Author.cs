using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }

        public string ShortName { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
