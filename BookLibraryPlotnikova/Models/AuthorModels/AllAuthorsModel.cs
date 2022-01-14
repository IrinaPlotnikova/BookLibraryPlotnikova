using BLL.Filters;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPlotnikova.Models.AuthorModels
{
    public class AllAuthorsModel
    {
        public ICollection<Author> Authors { get; set; } = new List<Author>();

        public IEnumerable<SelectListItem> AvailableCountries { get; set; } = new List<SelectListItem>();

        public AuthorFilter AuthorFilter { get; set;} = new AuthorFilter();
    }
}
