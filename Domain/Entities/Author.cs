using System.Collections.Generic;

namespace Domain.Entities
{
    public class Author : IBaseEntity
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string ShortName { get; set; }

        public int? CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
