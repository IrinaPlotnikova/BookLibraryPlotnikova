using BLL.Filters;
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
    public class CreateBookModel
    {
        public int Id { get; set; }


        [Required (ErrorMessage = "Не указано название")]
        [Remote(action: "VerifyName", controller: "Book", AdditionalFields = nameof(Id), ErrorMessage ="Книга уже зарегистрирована")]
        public string Name { get; set; } = "";
        

        [Required (ErrorMessage = "Не указано количество книг")]
        [Range(1, int.MaxValue, ErrorMessage = "Недопустимое количество книг")]
        public int NumberOfCopies { get; set; } = 10;


        [Required (ErrorMessage = "Не указано количество страниц")]
        [Range(1, int.MaxValue, ErrorMessage = "Недопустимое количество страниц")]
        public int NumberOfPages { get; set; } = 100;


        [Required (ErrorMessage = "Не указан год издания")]
        [Range(1800, int.MaxValue, ErrorMessage = "Недопустимый год издания")]
        public int PublishmentYear { get; set; } = 2000;

        
        [Required (ErrorMessage = "Не указана цена")]
        [Range(1, int.MaxValue, ErrorMessage = "Недопустимая цена")]
        public int Price { get; set; } = 1000;


        public int? GenreId { get; set; }


        public int? PublisherId { get; set; }


        public AuthorFilter AuthorFilter { get; set;} = new AuthorFilter();


        public BookFilter BookFilter { get; set;} = new BookFilter();


        public IEnumerable<SelectListItem> AvailableAuthors { get; set; } = new List<SelectListItem>();


        public IEnumerable<SelectListItem> AvailableGenres { get; set; } = new List<SelectListItem>();


        public IEnumerable<SelectListItem> AvailablePublishers { get; set; } = new List<SelectListItem>();
    }
}
