using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Book : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfPages { get; set; }

        public int PublishmentYear { get; set; }

        public int Price { get; set; }

        public int? GenreId { get; set; }

        public Genre Genre { get; set; }

        public int? PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();

        public ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();
        
    }
}
