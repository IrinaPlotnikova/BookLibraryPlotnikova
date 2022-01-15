using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Publisher : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}