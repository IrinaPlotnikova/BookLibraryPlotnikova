using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Filters
{
    public class AuthorFilter
    {
        public ICollection<int?> CountriesId { get; set; } = new List<int?>();

        public ICollection<int> Ids { get; set; } = new List<int>();
    }
}
