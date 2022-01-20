using BLL.Interfaces;
using DAL.Repositories;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> repository;

        public CountryService(IRepository<Country> repository)
        {
            this.repository = repository;
        }

        public Task CreateCountry(Country country)
        {
            return repository.CreateAsync(country);
        }

        public Task<Country> DeleteCountry(int countryId)
        {
            return repository.DeleteItemAsync(countryId);
        }

        public Task<ICollection<Country>> GetAllCountries()
        {
            return repository.GetAllAsync();
        }

        public async Task<ICollection<Author>> GetAuthorsByCountryId(int countryId)
        {
            return (await repository.GetByIdAsync(countryId)).Authors;
        }

        public Task<Country> GetCountryById(int countrytId)
        {
            return repository.GetByIdAsync(countrytId);
        }

        public async Task<ICollection<Publisher>> GetPublishersByCountryId(int countryId)
        {
            return (await repository.GetByIdAsync(countryId)).Publishers;
        }

        public Task UpdateCountry(Country country)
        {
            return repository.UpdateItemAsync(country);
        }

        public Task CreateCountries(IEnumerable<Country> countries)
        {
            return repository.CreateRangeAsync(countries);
        }

        public Task DeleteAll()
        {
            return repository.Clear();
        }
    }
}
