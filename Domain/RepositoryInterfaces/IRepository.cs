using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IRepository<T>
    {
        public Task<T> GetByIdAsync(int id);

        public Task CreateAsync(T item);

        public Task CreateRangeAsync(Iterable<T> items);

        public Task UpdateItemAsync(T item);

        public Task<T> DeleteItemAsync(int id);

        public Task<ICollection<T>> GetAllAsync();

        public Task<ICollection<T>> GetByFilterAsync(Expression<Func<T, bool>> expression);
    }
}
