using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class SampleData
    {
        public static void Initialize(LibraryContext context)
        {
            if (!context.BookStatuses.Any())
            {
                context.BookStatuses.AddRange(bookStatuses);
                context.SaveChanges();
            }

            if (!context.MoneyTransactionTypes.Any())
            {
                context.MoneyTransactionTypes.AddRange(moneyTransactionTypes);
                context.SaveChanges();
            }

            if (!context.Genres.Any())
            {
                context.Genres.AddRange(genres);
                context.SaveChanges();
            }

            if (!context.Countries.Any())
            {
                context.Countries.AddRange(countries);
                context.SaveChanges();
            }
        }


        private static readonly ICollection<BookStatus> bookStatuses = new BookStatus[] 
        {
            new BookStatus()
            { 
                Id = 1, 
                Name = " В библиотеке",
            },
            new BookStatus()
            { 
                Id = 2, 
                Name = "У читателя",
            },
            new BookStatus()
            { 
                Id = 3, 
                Name = "Списана",
            },
        };

        private static readonly ICollection<MoneyTransactionType> moneyTransactionTypes = new MoneyTransactionType[] 
        {
            new MoneyTransactionType()
            { 
                Id = 1, 
                Name = "Покупка библиотекой книги",
            },
            new MoneyTransactionType()
            { 
                Id = 2, 
                Name = "Оплата штрафа за просроченную книгу",
            },
        };


        private static readonly ICollection<Genre> genres = new Genre[] 
        {
            new Genre()
            {
                Id = 1,
                Name = "Другое",
            },
            new Genre()
            {
                Id = 2,
                Name = "Для детей",
            },
            new Genre()
            {
                Id = 3,
                Name = "Фантастика",
            },
            new Genre()
            {
                Id = 4,
                Name = "Классика",
            },
        };

        private static readonly ICollection<Country> countries = new Country[] 
        {
            new Country()
            {
                Id = 1,
                Name = "Другое",
            },
            new Country()
            {
                Id = 2,
                Name = "Россия",
            },
            new Country()
            {
                Id = 3,
                Name = "Великобритания",
            },
            new Country()
            {
                Id = 4,
                Name = "США",
            },
        };
    }
}
