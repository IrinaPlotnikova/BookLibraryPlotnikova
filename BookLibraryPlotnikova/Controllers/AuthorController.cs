using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryPlotnikova.Models;
using LibraryPlotnikova.Models.AuthorModels;
using BLL.Filters;

namespace LibraryPlotnikova.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ICountryService countryService;
        private readonly IAuthorService authorService;

        public AuthorController(ICountryService countryService, IAuthorService authorService)
        {
            this.countryService = countryService;
            this.authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            AllAuthorsModel model = new AllAuthorsModel()
            {
                Authors = await authorService.GetAllAuthors(),
                AvailableCountries = (await countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
            };
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> IndexWithFilter(AllAuthorsModel model)
        {
            model.Authors = await authorService.GetAuthorsByCountries(model.AuthorFilter);
            model.AvailableCountries = (await countryService.GetAllCountries()).Select(e => new SelectListItem() {
                Value = e.Id.ToString(),
                Text = e.Name,
                Selected = model.AuthorFilter.CountriesId.Contains(e.Id)
                });
            return View("Index", model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateAuthorModel model =  new CreateAuthorModel()
            {
                AvailableCountries = (await countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
            };
            return View("Create", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromModel(CreateAuthorModel model)
        {
            Author authorFromModel = new Author
            {
                Id = model.Id,
                FullName = model.FullName,
                ShortName = model.ShortName,
                CountryId = model.CountryId,
            };
            

            if (authorFromModel.Id == 0)
            {
                await authorService.AddAuthor(authorFromModel);
            }
            else
            {
                Author author = await authorService.GetAuthorById(authorFromModel.Id);
                author.FullName = authorFromModel.FullName;
                author.ShortName = authorFromModel.ShortName;
                author.CountryId = authorFromModel.CountryId;
                await authorService.UpdateAuthor(author);
            }

            return RedirectToAction("Info", new { id = authorFromModel.Id});
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await authorService.DeleteAuthor(id);
            }
            catch (Exception) { } // повторное удаление
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Change(int id)
        {
            Author author = await authorService.GetAuthorById(id);
            CreateAuthorModel model = new CreateAuthorModel()
            {
                Id = id,
                FullName = author.FullName,
                ShortName = author.ShortName,
                CountryId = author.CountryId,
                AvailableCountries = (await countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
            };
            return View("Create", model);
        }


        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            return View("Info", await authorService.GetAuthorById(id));
        }


        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> VerifyFullName(string fullName, int id)
        {
            IEnumerable<int> authorsId = (await authorService.GetAuthorsByFullName(fullName)).Select(r => r.Id);
            return Json(authorsId.Count() == 0 || authorsId.Contains(id));
        }
    }
}
