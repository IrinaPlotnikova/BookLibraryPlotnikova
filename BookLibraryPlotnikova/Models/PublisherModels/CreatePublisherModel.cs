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
    public class CreatePublisherModel
    {
        public int Id { get; set; }


        [Required (ErrorMessage = "Не указано название")]
        [Remote(action: "VerifyName", controller: "Publisher", AdditionalFields = nameof(Id), ErrorMessage ="Издатель уже зарегистрирован")]
        public string Name { get ; set;} = "";


        public int? CountryId { get; set;}


        public IEnumerable<SelectListItem> AvailableCountries { get; set; } = new List<SelectListItem>();
    }
}
