using BLL.Filters;
using BLL.Interfaces;
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
    public class BookCheckoutService : IBookCheckoutService
    {
        private readonly IRepository<BookCheckout>  repository;

        public BookCheckoutService(IRepository<BookCheckout> repository)
        {
            this.repository = repository;
        }

        public Task AddBookCheckout(BookCheckout bookCheckout)
        {
            return repository.CreateAsync(bookCheckout);
        }

        public Task UpdateBookCheckout(BookCheckout bookCheckout)
        {
            return repository.UpdateItemAsync(bookCheckout);
        }

        public Task<ICollection<BookCheckout>> GetBookCheckoutsByReaderId(int readerId)
        {
            Expression<Func<BookCheckout, bool>> expression = e => e.ReaderId == readerId;
            return repository.GetByFilterAsync(expression);
        }

        public Task<BookCheckout> GetBookCheckoutById(int bookCheckoutId)
        {
            return repository.GetByIdAsync(bookCheckoutId);
        }

        public Task<ICollection<BookCheckout>> GetBookCheckoutsToReadersByDates(DateFilter filter)
        {
            Expression<Func<BookCheckout, bool>> expression = e => filter.FirstDate <= e.DateStart && e.DateStart <= filter.LastDate;
            return repository.GetByFilterAsync(expression);
        }

        public Task<ICollection<BookCheckout>> GetBookCheckoutsFromReadersByDates(DateFilter filter)
        {
            Expression<Func<BookCheckout, bool>> expression = e => e.DateBookReturned != null &&
                filter.FirstDate <= e.DateBookReturned && e.DateBookReturned <= filter.LastDate;
            return repository.GetByFilterAsync(expression);
        }
    }
}
