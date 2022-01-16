using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPlotnikova.Models
{
    public class CreateAuthorModel
    {
        [Required (ErrorMessage = "Не указано полное имя")]
        public string FullName { get; set; } = "";

        [Required (ErrorMessage = "Не указано краткое имя")]
        public string ShortName { get; set; } = "";

        public int? CountryId { get; set; }

        public IEnumerable<SelectListItem> AvailableCountries { get; set; } = new List<SelectListItem>();
    }
}
