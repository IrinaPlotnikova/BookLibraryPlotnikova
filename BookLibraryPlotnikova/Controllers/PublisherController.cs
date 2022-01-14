using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryPlotnikova.Models;
using BLL.Filters;

namespace LibraryPlotnikova.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ICountryService countryService;
        private readonly IPublisherService publisherService;

        public PublisherController(ICountryService countryService, IPublisherService publisherService)
        {
            this.countryService = countryService;
            this.publisherService = publisherService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            AllPublishersModel model = new AllPublishersModel()
            {
                Publishers = await publisherService.GetAllPublishers(),
                AvailableCountries = (await countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
            };
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> IndexWithFilter(AllPublishersModel model)
        {
            model.Publishers = await publisherService.GetPublisherByCountries(model.PublisherFilter);
            model.AvailableCountries = (await countryService.GetAllCountries()).Select(e => new SelectListItem() {
                Value = e.Id.ToString(),
                Text = e.Name,
                Selected = model.PublisherFilter.CountriesId.Contains(e.Id)
                });
            return View("Index", model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreatePublisherModel model =  new CreatePublisherModel()
            {
                AvailableCountries = (await countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
            };
            return View("Create", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromModel(CreatePublisherModel model)
        {
            Publisher publisherFromModel = new Publisher()
            {
                Id = model.Id,
                Name = model.Name,
                CountryId = model.CountryId
            };

            if (publisherFromModel.Id == 0)
            {
                await publisherService.CreatePublisher(publisherFromModel);
            }
            else
            {
                Publisher publisher = await publisherService.GetPublisherById(model.Id);
                publisher.Name = model.Name;
                publisher.CountryId = model.CountryId;
                await publisherService.UpdatePublisher(publisher);
            }

            return RedirectToAction("Info", new { id = publisherFromModel.Id});
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await publisherService.DeletePublisher(id);
            }
            catch (Exception) { } // повторное удаление
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Change(int id)
        {
            Publisher publisher = await publisherService.GetPublisherById(id);
            CreatePublisherModel model = new CreatePublisherModel()
            {
                Id = publisher.Id,
                Name = publisher.Name,
                CountryId = publisher.CountryId,
                AvailableCountries = (await countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
            };
            return View("Create", model);
        }


        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            return View("Info", await publisherService.GetPublisherById(id));
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> VerifyName(string name, int id)
        {
            IEnumerable<int> publishersId = (await publisherService.GetPublishersByName(name)).Select(r => r.Id);
            return Json(publishersId.Count() == 0 || publishersId.Contains(id));
        }
    }
}
