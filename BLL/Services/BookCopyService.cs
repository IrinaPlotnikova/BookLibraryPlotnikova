﻿using BLL.Interfaces;
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
    public class BookCopyService : IBookCopyService
    {

        IRepository<BookCopy> repository;

        public BookCopyService(IRepository<BookCopy> repository)
        {
            this.repository = repository;
        }


        public Task AddBookCopy(BookCopy bookCopy)
        {
            return repository.CreateAsync(bookCopy);
        }

        public Task<ICollection<BookCopy>> GetAvailableCopiesByBookId(int bookId)
        {
            Expression<Func<BookCopy, bool>> expression = e => e.BookId == bookId && e.BookStatusId == 1;
            return repository.GetByFilterAsync(expression);
        }

        public Task UpdateBookCopy(BookCopy bookCopy)
        {
            return repository.UpdateItemAsync(bookCopy);
        }
    }
}
