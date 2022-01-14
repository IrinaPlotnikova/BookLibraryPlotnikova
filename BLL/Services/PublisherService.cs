using BLL.Filters;
using BLL.Interfaces;
using DAL.Repositories;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly  IRepository<Publisher> repository;

        public PublisherService(IRepository<Publisher> repository)
        {
            this.repository = repository;
        }

        public Task CreatePublisher(Publisher publisher)
        {
            return repository.CreateAsync(publisher);
        }

        public Task<Publisher> DeletePublisher(int publisherId)
        {
            return repository.DeleteItemAsync(publisherId);
        }

        public Task<ICollection<Publisher>> GetAllPublishers()
        {
            return repository.GetAllAsync();
        }

        public Task<Publisher> GetPublisherById(int publisherId)
        {
            return repository.GetByIdAsync(publisherId);
        }

        public Task UpdatePublisher(Publisher publisher)
        {
            return repository.UpdateItemAsync(publisher);
        }

        public Task<ICollection<Publisher>> GetPublisherByCountries(PublisherFilter filter)
        {
            bool isEmpty = filter.CountriesId.Count == 0;
            Expression<Func<Publisher, bool>> expression = e => isEmpty || filter.CountriesId.Contains(e.CountryId);
            return repository.GetByFilterAsync(expression);
        }

        public Task<ICollection<Publisher>> GetPublishersByName(string name)
        {
            Expression<Func<Publisher, bool>> expression = e => e.Name == name;
            return repository.GetByFilterAsync(expression);
        }
    }
}
 