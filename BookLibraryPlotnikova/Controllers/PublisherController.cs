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
            publisherFilter ??= new PublisherFilter();

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

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreatePublisherModel model =  new CreatePublisherModel()
            {
                AvailableCountries = (await countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromModel([FromForm] Publisher publisher)
        {
            if (!await VerifyPublisher(publisher))
            {
                return BadRequest();
            }

            if (!await VerifyDistincPublisherName(publisher.Name))
            {
                ModelState.AddModelError("Name", "Издатель с таким названием уже существует");
            }

            if (!ModelState.IsValid)
            {
                CreatePublisherModel model = new CreatePublisherModel()
                {
                    Name = publisher.Name,
                    CountryId = publisher.CountryId,
                    AvailableCountries = (await countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
                };

                return View("Create", model);
            }

            await publisherService.CreatePublisher(publisher);

            return RedirectToAction(nameof(Info), new { id = publisher.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Publisher publisher = await publisherService.GetPublisherById(id);
            if (publisher == null)
            {
                 return NotFound();
            }

            UpdatePublisherModel model =  new UpdatePublisherModel()
            {
                Id = id,
                Name = publisher.Name,
                CountryId = publisher.CountryId,
                AvailableCountries = (await countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFromModel([FromForm] Publisher publisherFromModel)
        {
            Publisher publisher = await publisherService.GetPublisherById(publisherFromModel.Id);
            if (publisher == null)
            {
                return NotFound();
            }

            if (!await VerifyPublisher(publisherFromModel))
            {
                return BadRequest();
            }

            if (!await VerifyDistincPublisherName(publisherFromModel.Name, publisherFromModel.Id))
            {
                ModelState.AddModelError("Name", "Издатель с таким названием уже существует");
            }

            if (!ModelState.IsValid)
            {
                UpdatePublisherModel model = new UpdatePublisherModel()
                {
                    Name = publisherFromModel.Name,
                    CountryId = publisherFromModel.CountryId,
                    AvailableCountries = (await countryService.GetAllCountries()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
                };

                return View("Update", model);
            }

            publisher.Name = publisherFromModel.Name;
            publisher.CountryId = publisherFromModel.CountryId;
            await publisherService.UpdatePublisher(publisher);

            return RedirectToAction(nameof(Info), new { id = publisher.Id});
        }

        [HttpGet]
        public async Task<IActionResult> DeletionAttempt(int id)
        {
            Publisher publisher = await publisherService.GetPublisherById(id);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await publisherService.GetPublisherById(id) == null)
            {
                return NotFound();
            }

            await publisherService.DeletePublisher(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            Publisher publisher = await publisherService.GetPublisherById(id);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        private async Task<bool> VerifyPublisher(Publisher publisher)
        {   
            return publisher != null &&
                !string.IsNullOrWhiteSpace(publisher.Name) && publisher.Name.Length <= 100 && 
                (publisher.CountryId == null || (await countryService.GetCountryById(publisher.CountryId.Value)) != null);
        }

        private async Task<bool> VerifyDistincPublisherName(string name, int id = 0)
        {
            if (name == null)
                return false;

            IEnumerable<int> publishersId = (await publisherService.GetPublishersByName(name)).Select(r => r.Id);

            return  !publishersId.Any() || publishersId.Contains(id);
        }
    }
}
