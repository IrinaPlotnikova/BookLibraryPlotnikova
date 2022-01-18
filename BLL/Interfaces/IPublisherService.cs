using BLL.Filters;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPublisherService
    {
        public Task CreatePublisher(Publisher publisher);

        public Task CreatePublishers(IEnumerable<Publisher> publishers);

        public Task UpdatePublisher(Publisher publisher);

        public Task<Publisher> DeletePublisher(int publisherId);

        public Task<ICollection<Publisher>> GetAllPublishers();

        public Task<Publisher> GetPublisherById(int publisherId);

        public Task<ICollection<Publisher>> GetPublisherByCountries(PublisherFilter filter);

        public Task<ICollection<Publisher>> GetPublishersByName(string name);

        public Task DeleteAll();
    }
}
