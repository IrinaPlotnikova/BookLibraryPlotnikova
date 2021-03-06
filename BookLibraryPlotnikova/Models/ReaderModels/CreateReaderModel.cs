using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPlotnikova.Models.ReaderModels
{
    public class CreateReaderModel
    {
        [Required (ErrorMessage = "Не указано имя")]
        public string Name { get; set; } = "";

        [Required (ErrorMessage = "Не указан email")]
        [EmailAddress (ErrorMessage = "Некорректный email")]
        public string Email { get; set; } = "";

        [Required (ErrorMessage = "Не указан паспорт")]
        public string Passport { get; set; } = "";
    }
}
