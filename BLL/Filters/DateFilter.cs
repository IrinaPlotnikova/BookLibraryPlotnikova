using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Filters
{
    public class DateFilter
    {
        public DateTime FirstDate { get; set; } = DateTime.Today.AddYears(-1);

        public DateTime LastDate { get; set; } = DateTime.Today;
    }

}
