using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryPlotnikova.Models.AuthorModels
{
    public class UpdateAuthorModel
    {
        public int Id { get; set;}

        [Required (ErrorMessage = "Не указано полное имя")]
        public string FullName { get; set; } = "";

        [Required (ErrorMessage = "Не указано краткое имя")]
        public string ShortName { get; set; } = "";

        public int? CountryId { get; set; }

        public IEnumerable<SelectListItem> AvailableCountries { get; set; } = new List<SelectListItem>();
    }
}
