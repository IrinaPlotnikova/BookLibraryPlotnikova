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
        private readonly ICountryService _countryService;
        private readonly IAuthorService _authorService;

        public AuthorController(ICountryService countryService, IAuthorService authorService)
        {
            _countryService = countryService;
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] AuthorFilter authorFilter)
        {
            authorFilter ??= new AuthorFilter();

            AllAuthorsModel model = new AllAuthorsModel()
            {
                Authors = await _authorService.GetAuthorsByCountries(authorFilter),
                AvailableCountries = (await _countryService.GetAllCountries()).Select(e => new SelectListItem() {
                Value = e.Id.ToString(),
                Text = e.Name,
                Selected = authorFilter.CountriesId.Contains(e.Id)
                }),
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateAuthorModel model =  new CreateAuthorModel()
            {
                AvailableCountries = (await _countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromModel([FromForm] Author author)
        {
            if (!await VerifyAuthor(author))
            {
                return BadRequest();
            }

            if (!await VerifyDistinctAuthorName(author.FullName))
            {
                ModelState.AddModelError("FullName", "Автор с указанным полным именем уже существует");
            }

            if (!ModelState.IsValid)
            {
                CreateAuthorModel model = new CreateAuthorModel()
                {
                    FullName = author.FullName,
                    ShortName = author.ShortName,
                    CountryId = author.Country?.Id,
                    AvailableCountries = (await _countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
                };

                return View("Create", model);
            }
 
            await _authorService.CreateAuthor(author);

            return RedirectToAction(nameof(Info), new { id = author.Id});
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Author author = await _authorService.GetAuthorById(id);
            if (author == null)
            {
                 return NotFound();
            }

            UpdateAuthorModel model =  new UpdateAuthorModel()
            {
                Id = id,
                FullName = author.FullName,
                ShortName = author.ShortName,
                CountryId = author.CountryId,
                AvailableCountries = (await _countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFromModel([FromForm] Author authorFromModel)
        {
            Author author = await _authorService.GetAuthorById(authorFromModel.Id);
            if (author == null)
            {
                return NotFound();
            }

            if (!await VerifyAuthor(authorFromModel))
            {
                return BadRequest();
            }

            if (!await VerifyDistinctAuthorName(authorFromModel.FullName, authorFromModel.Id))
            {
                ModelState.AddModelError("FullName", "Автор с указанным полным именем уже существует");
            }

            if (!ModelState.IsValid)   
            {
                UpdateAuthorModel model = new UpdateAuthorModel()
                {
                    FullName = authorFromModel.FullName,
                    ShortName = authorFromModel.ShortName,
                    CountryId = authorFromModel.CountryId,
                    AvailableCountries = (await _countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
                };

                return View("Update", model);
            }

            author.FullName = authorFromModel.FullName;
            author.ShortName = authorFromModel.ShortName;
            author.CountryId = authorFromModel.CountryId;
            await _authorService.UpdateAuthor(author);

            return RedirectToAction(nameof(Info), new { id = author.Id});
        }

        [HttpGet]
        public async Task<IActionResult> DeletionAttempt(int id)
        {
            Author author = await _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _authorService.GetAuthorById(id) == null)
            {
                return NotFound();
            }
            await _authorService.DeleteAuthor(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            Author author = await _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        private async Task<bool> VerifyAuthor(Author author)
        {
            return author != null &&
                !string.IsNullOrWhiteSpace(author.FullName) && author.FullName.Count() <= 100 &&
                !string.IsNullOrWhiteSpace(author.ShortName) && author.ShortName.Count() <= 30 &&
                (author.CountryId == null || await _countryService.GetCountryById(author.CountryId.Value) != null);
        }

        private async Task<bool> VerifyDistinctAuthorName(string name, int id = 0)
        {
            if (name == null) 
                return false;

            IEnumerable<int> authorsId = (await _authorService.GetAuthorsByFullName(name)).Select(e => e.Id);

            return !authorsId.Any() || authorsId.Contains(id);
        }
    }
}
