using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Country : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();

        public ICollection<Publisher> Publishers { get; set; } = new List<Publisher>();
    }
}