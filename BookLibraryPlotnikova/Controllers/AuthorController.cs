﻿using Domain.Entities;
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
            if (authorFilter == null)
            {
                authorFilter = new AuthorFilter();
            }

            AllAuthorsModel model = new AllAuthorsModel()
            {
                Authors = await _authorService.GetAuthorsByCountries(authorFilter),
                AvailableCountries = (await _countryService.GetAllCountries()).Select(e => new SelectListItem() {
                Value = e.Id.ToString(),
                Text = e.Name,
                Selected = authorFilter.CountriesId.Contains(e.Id)
                }),
            };
            return View("Index", model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateAuthorModel model =  new CreateAuthorModel()
            {
                AvailableCountries = (await _countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
            };
            return View("Create", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromModel([FromForm] Author author)
        {
            if (author == null || !await VerifyAuthor(author))
            {
                return RedirectToAction("Index");
            }
 
            await _authorService.CreateAuthor(author);
            return RedirectToAction("Info", new { id = author.Id});
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Author author = await _authorService.GetAuthorById(id);
            if (author == null)
            {
                 return RedirectToAction("Index");
            }

            UpdateAuthorModel model =  new UpdateAuthorModel()
            {
                Id = id,
                FullName = author.FullName,
                ShortName = author.ShortName,
                CountryId = author.CountryId,
                AvailableCountries = (await _countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
            };
            return View("Update", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFromModel([FromForm] Author authorFromModel)
        {
            if (authorFromModel == null || !await VerifyAuthor(authorFromModel))
            {
                return RedirectToAction("Index");
            }

            Author author = await _authorService.GetAuthorById(authorFromModel.Id);
            if (author == null)
            {
                return RedirectToAction("Index");
            }

            author.FullName = authorFromModel.FullName;
            author.ShortName = authorFromModel.ShortName;
            author.CountryId = authorFromModel.CountryId;
            await _authorService.UpdateAuthor(author);
            return RedirectToAction("Info", new { id = author.Id});
        }

        [HttpGet]
        public async Task<IActionResult> DeletionAttempt(int id)
        {
            Author author = await _authorService.GetAuthorById(id);
            if (author == null)
            {
                return RedirectToAction("Index");
            }
            return View("ConfirmDeletion", author);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _authorService.GetAuthorById(id) != null)
            {
                await _authorService.DeleteAuthor(id);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            Author author = await _authorService.GetAuthorById(id);
            if (author == null)
            {
                return RedirectToAction("Index");
            }
            return View("Info", author);
        }

        private async Task<bool> VerifyAuthor(Author author)
        {
            IEnumerable<int> authorsId = (await _authorService.GetAuthorsByFullName(author.FullName)).Select(e => e.Id);
            return !string.IsNullOrWhiteSpace(author.FullName) && author.FullName.Count() <= 100 &&
                !string.IsNullOrWhiteSpace(author.ShortName) && author.ShortName.Count() <= 30 &&
                (!authorsId.Any() || authorsId.Contains(author.Id)) &&
                (author.CountryId == null || await _countryService.GetCountryById(author.CountryId.Value) != null);
        }
    }
}
