using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }

        public int NumberOfPages { get; set; }

        public int PublishmentYear { get; set; }

        public int Price { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();

        public ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();
        
    }
}
