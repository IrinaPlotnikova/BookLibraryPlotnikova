using BLL.Filters;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LibraryPlotnikova.Models
{
    public class AllPublishersModel
    {
        public ICollection<Publisher> Publishers { get; set; } = new List<Publisher>();

        public IEnumerable<SelectListItem> AvailableCountries { get; set; } = new List<SelectListItem>();

        public ICollection<int?> CountriesId { get; set;} = new List<int?>();

        public PublisherFilter PublisherFilter { get; set; } = new PublisherFilter();
    }
}
