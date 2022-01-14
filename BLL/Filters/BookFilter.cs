using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Filters
{
    public class BookFilter
    {
        public ICollection<int?> GenresId { get; set; } = new List<int?>();

        public ICollection<int> AuthorsId { get; set; } = new List<int>();

        public ICollection<int?> PublishersId { get; set; } = new List<int?>();
    }
}
