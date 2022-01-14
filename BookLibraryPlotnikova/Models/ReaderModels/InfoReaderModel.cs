using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPlotnikova.Models.ReaderModels
{
    public class InfoReaderModel
    {
        public Reader Reader { get; set; } = new Reader();

        public IEnumerable<BookCheckout> BookCheckoutsCurrent = new List<BookCheckout>();

        public IEnumerable<BookCheckout> BookCheckoutsHistory = new List<BookCheckout>();
    }
}
