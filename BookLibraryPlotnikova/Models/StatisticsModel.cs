using BLL.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPlotnikova.Models
{
    public class StatisticsModel
    {
        public DateFilter DateFilter { get; set;} = new DateFilter();

        public string[] AvailableStatisticsTypes = new[] { "выдача / приём", "денежные операции"};

        public string StatisticsType { get; set;} = "выдача / приём";
    }
}
