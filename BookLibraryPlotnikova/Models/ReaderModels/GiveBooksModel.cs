using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPlotnikova.Models.ReaderModels
{
    public class GiveBooksModel
    {
        public Reader Reader { get; set; } = new Reader();

        public IEnumerable<SelectListItem> AvailableBooks { get; set; } = new List<SelectListItem>();

        public ICollection<int> SelectedBooksId { get; set; } = new List<int>();
    }
}