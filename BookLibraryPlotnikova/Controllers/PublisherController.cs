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
using LibraryPlotnikova.Models.PublisherModels;

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
        public async Task<IActionResult> Index([FromQuery] PublisherFilter publisherFilter)
        {
            if (publisherFilter == null)
            {
                publisherFilter = new PublisherFilter();
            }

            AllPublishersModel model = new AllPublishersModel()
            {
                Publishers = await publisherService.GetPublisherByCountries(publisherFilter),
                AvailableCountries = (await countryService.GetAllCountries()).Select(e => new SelectListItem() 
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name,
                        Selected = publisherFilter.CountriesId.Contains(e.Id)
                    }),
            };
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
        public async Task<IActionResult> CreateFromModel([FromForm] Publisher publisher)
        {
            if (publisher == null || !await VerifyPublisher(publisher))
            {
                return RedirectToAction("Index");
            }

            await publisherService.CreatePublisher(publisher);
            return RedirectToAction("Info", new { id = publisher.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Publisher publisher = await publisherService.GetPublisherById(id);
            if (publisher == null)
            {
                 return RedirectToAction("Index");
            }

            UpdatePublisherModel model =  new UpdatePublisherModel()
            {
                Id = id,
                Name = publisher.Name,
                CountryId = publisher.CountryId,
                AvailableCountries = (await countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
            };
            return View("Update", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFromModel([FromForm] Publisher publisherFromModel)
        {
            if (publisherFromModel == null || !await VerifyPublisher(publisherFromModel))
            {
                return RedirectToAction("Index");
            }

            Publisher publisher = await publisherService.GetPublisherById(publisherFromModel.Id);
            if (publisher == null)
            {
                return RedirectToAction("Index");
            }

            publisher.Name = publisherFromModel.Name;
            publisher.CountryId = publisherFromModel.CountryId;
            await publisherService.UpdatePublisher(publisher);
            return RedirectToAction("Info", new { id = publisher.Id});
        }

        [HttpGet]
        public async Task<IActionResult> DeletionAttempt(int id)
        {
            Publisher publisher = await publisherService.GetPublisherById(id);
            if (publisher == null)
            {
                return RedirectToAction("Index");
            }
            return View("ConfirmDeletion", publisher);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await publisherService.GetPublisherById(id) != null)
            {
                await publisherService.DeletePublisher(id);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            Publisher publisher = await publisherService.GetPublisherById(id);
            if (publisher == null)
            {
                return RedirectToAction("Index");
            }
            return View("Info", publisher);
        }

        private async Task<bool> VerifyPublisher(Publisher publisher)
        {
            IEnumerable<int> publishersId = (await publisherService.GetPublishersByName(publisher.Name)).Select(r => r.Id);
            return !string.IsNullOrWhiteSpace(publisher.Name) && publisher.Name.Length <= 100 && 
                (!publishersId.Any() || publishersId.Contains(publisher.Id)) &&
                (publisher.CountryId == null || (await countryService.GetCountryById(publisher.CountryId.Value)) != null);
        }
    }
}
