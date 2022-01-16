using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryPlotnikova.Models.PublisherModels
{
    public class UpdatePublisherModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Не указано название")]
        public string Name { get ; set;} = "";

        public int? CountryId { get; set;}

        public IEnumerable<SelectListItem> AvailableCountries { get; set; } = new List<SelectListItem>();
    }
}
