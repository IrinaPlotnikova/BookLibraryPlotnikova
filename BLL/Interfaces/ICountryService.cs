using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICountryService
    {
        public Task AddCountry(Country country);

        public Task UpdateCountry(Country country);

        public Task<Country> DeleteCountry(int countryId);

        public Task<ICollection<Country>> GetAllCountries();

        public Task<Country> GetCountryById(int countrytId);

        public Task<ICollection<Publisher>> GetPublishersByCountryId(int countryId);

        public Task<ICollection<Author>> GetAuthorsByCountryId(int countryId);
    }
}
