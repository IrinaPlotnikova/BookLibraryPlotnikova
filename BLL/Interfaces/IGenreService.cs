using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenreService
    {
        public Task<ICollection<Genre>> GetAllGenres();

        public Task<Genre> GetGenderById(int genderId);

        public Task DeleteAll();

         public Task CreateGenres(IEnumerable<Genre> genres);
    }
}
