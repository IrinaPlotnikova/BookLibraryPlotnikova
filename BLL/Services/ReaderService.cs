using BLL.Filters;
using BLL.Interfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReaderService : IReaderService
    {
        private readonly IRepository<Reader> repository;

        public ReaderService(IRepository<Reader> repository)
        {
            this.repository = repository;
        }

        public Task CreateReader(Reader reader)
        {
            return repository.CreateAsync(reader);
        }

        public Task CreateReaders(IEnumerable<Reader> readers)
        {
            return repository.CreateRangeAsync(readers);
        }

        public Task<ICollection<Reader>> GetAllReaders()
        {
            return repository.GetAllAsync();
        }

        public Task<ICollection<Reader>> GetReadersByPassport(string passport)
        {
           return repository.GetByFilterAsync(e => e.Passport.ToLower() == passport.ToLower());
        }

        public Task<Reader> DeleteReader(int authorId)
        {
            return repository.DeleteItemAsync(authorId);
        }

        public Task<Reader> GetReaderById(int readerId)
        {
            return repository.GetByIdAsync(readerId);
        }

        public Task UpdateReader(Reader reader)
        {
            return repository.UpdateItemAsync(reader);
        }

        public Task DeleteAll()
        {
            return repository.Clear();
        }
    }
}
