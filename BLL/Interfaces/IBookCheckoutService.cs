using BLL.Filters;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBookCheckoutService
    {
        public Task CreateBookCheckout(BookCheckout bookCheckout);

        public Task CreateBookCheckouts(IEnumerable<BookCheckout> bookCheckouts);

        public Task<BookCheckout> GetBookCheckoutById(int bookCheckoutId);

        public Task UpdateBookCheckout(BookCheckout bookCheckout);

        public Task<ICollection<BookCheckout>> GetBookCheckoutsByReaderId(int readerId);

        public Task<ICollection<BookCheckout>> GetBookCheckoutsToReadersByDates(DateFilter filter);

        public Task<ICollection<BookCheckout>> GetBookCheckoutsFromReadersByDates(DateFilter filter);

        public Task DeleteAll();
    }
}
