using BLL.Interfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> repository;

        public GenreService(IRepository<Genre> repository)
        {
            this.repository = repository;
        }

        public Task<ICollection<Genre>> GetAllGenres()
        {
            return repository.GetAllAsync();
        }

        public Task<Genre> GetGenderById(int genderId)
        {
            return repository.GetByIdAsync(genderId);
        }
    }
}
