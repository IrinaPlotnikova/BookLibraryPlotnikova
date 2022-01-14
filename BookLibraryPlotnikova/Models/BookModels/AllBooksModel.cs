using BLL.Filters;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPlotnikova.Models.BookModels
{
    public class AllBooksModel
    {
         public ICollection<Book> Books { get; set; } = new List<Book>();

        public IEnumerable<SelectListItem> AvailableGenres { get; set; } = new List<SelectListItem>();

        public IEnumerable<SelectListItem> AvailableAuthors { get; set; } = new List<SelectListItem>();

        public IEnumerable<SelectListItem> AvailablePublishers { get; set; } = new List<SelectListItem>();

        public BookFilter BookFilter { get; set; } = new BookFilter();
    }
}
