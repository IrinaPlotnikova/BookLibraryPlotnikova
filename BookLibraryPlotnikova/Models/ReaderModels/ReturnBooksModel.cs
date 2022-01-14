using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPlotnikova.Models.ReaderModels
{
    public class ReturnBooksModel
    {
        public Reader Reader { get; set;} = new Reader();

        public IEnumerable<SelectListItem> AvailableBookCheckouts { get; set;}

        public ICollection<int> SelectedBookCheckoutsId { get; set;} = new List<int>();
    }
}
