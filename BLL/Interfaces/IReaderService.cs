using BLL.Filters;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IReaderService
    {
        public Task CreateReader(Reader publisher);

        public Task UpdateReader(Reader reader);

        public Task<Reader> DeleteReader(int authorId);

        public Task<ICollection<Reader>> GetAllReaders();

        public Task<Reader> GetReaderById(int readerId);

        public Task<ICollection<Reader>> GetReadersByPassport(string passport);
    }
}
