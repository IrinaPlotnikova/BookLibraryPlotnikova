
using BLL.Interfaces;
using Domain.Entities;
using LibraryPlotnikova.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryPlotnikova.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService bookService;
        private readonly IReaderService readerService;
        private readonly IPublisherService publisherService;
        private readonly IAuthorService authorService;
        private readonly IBookCheckoutService bookCheckoutService;
        private readonly IBookCopyService bookCopyService;
        private readonly IMoneyTransactionService moneyTransactionService;

        public HomeController(IBookService bookService, IReaderService readerService, 
            IPublisherService publisherService, IAuthorService authorService, IBookCheckoutService bookCheckoutService,
            IBookCopyService bookCopyService, IMoneyTransactionService moneyTransactionService)
        {
            this.bookService = bookService;
            this.readerService = readerService;
            this.publisherService = publisherService;
            this.authorService = authorService;
            this.bookCheckoutService = bookCheckoutService;
            this.bookCopyService = bookCopyService;
            this.moneyTransactionService = moneyTransactionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> AddSampleData()
        {
            await publisherService.DeleteAll();
            await readerService.DeleteAll();
            await authorService.DeleteAll();
            await bookService.DeleteAll();
            await bookCopyService.DeleteAll();
            await bookCheckoutService.DeleteAll();
            await moneyTransactionService.DeleteAll();


            await publisherService.CreatePublishers(publishers);
            await readerService.CreateReaders(readers);
            await authorService.CreateAuthors(authors);
            await bookService.CreateBooks(books);
            await bookCopyService.CreateBookCopies(bookCopies);
            await bookCheckoutService.CreateBookCheckouts(bookCheckouts);
            await moneyTransactionService.CreateMoneyTransactions(moneyTransactions);

            return View("Index");
        }


        private readonly ICollection<Publisher> publishers = new Publisher[] 
        {
            new Publisher()
            {
                Id = 1,
                Name = "Другое",
                CountryId = 1,
            },
            new Publisher()
            {
                Id = 2,
                Name = "Махаон",
                CountryId = 2,
            },
            new Publisher()
            {
                Id = 3,
                Name = "АСТ",
                CountryId = 2,
            },
        };

        private readonly ICollection<Reader> readers = new Reader[] 
        {
            new Reader()
            {
                Id = 1,
                Name = "Волков Семён Артурович",
                Email = "volkov@gmail.com",
                Passport = "4656 172296",
            },
            new Reader()
            {
                Id = 2,
                Name = "Тарасов Александр Маркович",
                Email = "tarasov@gmail.com",
                Passport = "4714 166528",
            },
            new Reader()
            {
                Id = 3,
                Name = "Кукушкина Яна Артемьевна",
                Email = "kukushkina@gmail.com",
                Passport = "4850 435532",
            },
            new Reader()
            {
                Id = 4,
                Name = "Виноградов Иван Данилович",
                Email = "vinogradov@gmail.com",
                Passport = "4546 853306",
            },
            new Reader()
            {
                Id = 5,
                Name = "Сазонова Анна Платоновна",
                Email = "sazonova@gmail.com",
                Passport = "4336 285466",
            },
        };

        private static readonly ICollection<Author> authors = new Author[] 
        {
            new Author()
            {
                Id = 1,
                FullName = "Джоан Роулинг",
                ShortName = "Дж. К. Роулинг",
                CountryId = 3,
            },
            new Author()
            {
                Id = 2,
                FullName = "Фрэнк Герберт",
                ShortName = "Ф. Герберт",
                CountryId = 4,
            },
            new Author()
            {
                Id = 3,
                FullName = "Илья Арнольдович Ильф",
                ShortName = "И. А. Ильф",
                CountryId = 2,
            },
            new Author()
            {
                Id = 4,
                FullName = "Евгений Петров",
                ShortName = "Е. Петров",
                CountryId = 2,
            },
        };

        private readonly ICollection<Book> books = new Book[] 
        {
            new Book()
            {
                Id = 1,
                Name = "Гарри Поттер и философский камень",
                NumberOfPages = 432,
                PublishmentYear = 2014,
                Price = 508,
                GenreId = 2,
                PublisherId = 2,
                Authors = new Author[]{ authors.ElementAt(0)}
            },
                new Book()
                {
                    Id = 2,
                    Name = "Гарри Поттер и Тайная комната",
                    NumberOfPages = 480,
                    PublishmentYear = 2014,
                    Price = 508,
                    GenreId = 2,
                    PublisherId = 2,
                    Authors = new Author[]{ authors.ElementAt(0)}
                },
                new Book()
                {
                    Id = 3,
                    Name = "Гарри Поттер и узник Азкабана",
                    NumberOfPages = 528,
                    PublishmentYear = 2014,
                    Price = 508,
                    GenreId = 2,
                    PublisherId = 2,
                    Authors = new Author[]{ authors.ElementAt(0)}
                },
                new Book()
                {
                    Id = 4,
                    Name = "Гарри Поттер и Кубок Огня",
                    NumberOfPages = 704,
                    PublishmentYear = 2015,
                    Price = 640,
                    GenreId = 2,
                    PublisherId = 2,
                    Authors = new Author[]{ authors.ElementAt(0)}
                },
                new Book()
                {
                    Id = 5,
                    Name = "Гарри Поттер и Орден Феникса",
                    NumberOfPages = 896,
                    PublishmentYear = 2015,
                    Price = 730,
                    GenreId = 2,
                    PublisherId = 2,
                    Authors = new Author[]{ authors.ElementAt(0)}
                },
                new Book()
                {
                    Id = 6,
                    Name = "Гарри Поттер и Принц-полукровка",
                    NumberOfPages = 672,
                    PublishmentYear = 2015,
                    Price = 640,
                    GenreId = 2,
                    PublisherId = 2,
                    Authors = new Author[]{ authors.ElementAt(0)}
                },
                new Book()
                {
                    Id = 7,
                    Name = "Гарри Поттер и Дары смерти",
                    NumberOfPages = 704,
                    PublishmentYear = 2015,
                    Price = 640,
                    GenreId = 2,
                    PublisherId = 2,
                    Authors = new Author[]{ authors.ElementAt(0)}
                },
                new Book()
                {
                    Id = 8,
                    Name = "Дюна",
                    NumberOfPages = 704,
                    PublishmentYear = 2013,
                    Price = 656,
                    GenreId = 3,
                    PublisherId = 3,
                    Authors = new Author[]{ authors.ElementAt(1)}
                },
                new Book()
                {
                    Id = 9,
                    Name = "12 стульев",
                    NumberOfPages = 448,
                    PublishmentYear = 2012,
                    Price = 182,
                    GenreId = 3,
                    PublisherId = 3,
                    Authors = new Author[]{ authors.ElementAt(2), authors.ElementAt(3)}
                },
            };

            private readonly ICollection<BookCopy> bookCopies = new BookCopy[] 
            {
                new BookCopy()
                {
                    Id = 1,
                    BookId = 1,
                    BookStatusId = 2,
                    ReaderId = 1,
                },
                new BookCopy()
                {
                    Id = 2,
                    BookId = 1,
                    BookStatusId = 1,
                    ReaderId = null,
                },
                new BookCopy()
                {
                    Id = 3,
                    BookId = 2,
                    BookStatusId = 2,
                    ReaderId = 2,
                },
                new BookCopy()
                {
                    Id = 4,
                    BookId = 2,
                    BookStatusId = 1,
                    ReaderId = null,
                },
                new BookCopy()
                {
                    Id = 5,
                    BookId = 3,
                    BookStatusId = 1,
                    ReaderId = null,
                },
                new BookCopy()
                {
                    Id = 6,
                    BookId = 3,
                    BookStatusId = 1,
                    ReaderId = null,
                },
                new BookCopy()
                {
                    Id = 7,
                    BookId = 4,
                    BookStatusId = 1,
                    ReaderId = null,
                },
                new BookCopy()
                {
                    Id = 8,
                    BookId = 4,
                    BookStatusId = 1,
                    ReaderId = null,
                },
                new BookCopy()
                {
                    Id = 9,
                    BookId = 5,
                    BookStatusId = 1,
                    ReaderId = null,
                },
                new BookCopy()
                {
                    Id = 10,
                    BookId = 5,
                    BookStatusId = 1,
                    ReaderId = null,
                },
                new BookCopy()
                {
                    Id = 11,
                    BookId = 6,
                    BookStatusId = 1,
                    ReaderId = null,
                },
                new BookCopy()
                {
                    Id = 12,
                    BookId = 6,
                    BookStatusId = 1,
                    ReaderId = null,
                },
                new BookCopy()
                {
                    Id = 13,
                    BookId = 7,
                    BookStatusId = 2,
                    ReaderId = 3,
                },
                new BookCopy()
                {
                    Id = 14,
                    BookId = 8,
                    BookStatusId = 1,
                    ReaderId = null,
                },
                new BookCopy()
                {
                    Id = 15,
                    BookId = 9,
                    BookStatusId = 1,
                    ReaderId = null,
                },
            };

            private readonly ICollection<BookCheckout> bookCheckouts = new BookCheckout[] 
            {
                new BookCheckout()
                {
                    BookCopyId = 1,
                    ReaderId = 1,
                    DateStart = new DateTime(2021, 6, 5),
                    DateFinish = new DateTime(2021, 8, 5),
                    DateBookReturned = new DateTime(2021, 8, 3),
                    OverdueFine = 5,
                },
                new BookCheckout()
                {
                    BookCopyId = 2,
                    ReaderId = 2,
                    DateStart = new DateTime(2021, 7, 21),
                    DateFinish = new DateTime(2021, 10, 21),
                    DateBookReturned = new DateTime(2021, 10, 19),
                    OverdueFine = 5,
                },
                new BookCheckout()
                {
                    BookCopyId = 3,
                    ReaderId = 3,
                    DateStart = new DateTime(2021, 8, 12),
                    DateFinish = new DateTime(2021, 11, 12),
                    DateBookReturned = new DateTime(2021, 11, 10),
                    OverdueFine = 5,
                },
                new BookCheckout()
                {
                    BookCopyId = 4,
                    ReaderId = 4,
                    DateStart = new DateTime(2021, 9, 17),
                    DateFinish = new DateTime(2021, 12, 17),
                    DateBookReturned =  new DateTime(2021, 12, 19),
                    OverdueFine = 5,
                },
                new BookCheckout()
                {
                    BookCopyId = 5,
                    ReaderId = 5,
                    DateStart = new DateTime(2021, 10, 15),
                    DateFinish = new DateTime(2022, 1, 15),
                    DateBookReturned = new DateTime(2022, 1, 10),
                    OverdueFine = 5,
                },
                new BookCheckout()
                {
                    BookCopyId = 6,
                    ReaderId = 1,
                    DateStart = new DateTime(2021, 11, 23),
                    DateFinish = new DateTime(2022, 2, 23),
                    DateBookReturned = null,
                    OverdueFine = 5,
                },
                new BookCheckout()
                {
                    BookCopyId = 7,
                    ReaderId = 2,
                    DateStart = new DateTime(2021, 12, 9),
                    DateFinish = new DateTime(2022, 3, 9),
                    DateBookReturned = new DateTime(2022, 3, 12),
                    OverdueFine = 5,
                },
                new BookCheckout()
                {
                    BookCopyId = 8,
                    ReaderId = 3,
                    DateStart = new DateTime(2021, 9, 3),
                    DateFinish = new DateTime(2021, 12, 3),
                    DateBookReturned = null,
                    OverdueFine = 5,
                },
                new BookCheckout()
                {
                    BookCopyId = 9,
                    ReaderId = 4,
                    DateStart = new DateTime(2021, 10, 18),
                    DateFinish = new DateTime(2022, 1, 18),
                    DateBookReturned = null,
                    OverdueFine = 5,
                },
                new BookCheckout()
                {
                    BookCopyId = 10,
                    ReaderId = 5,
                    DateStart = new DateTime(2021, 11, 1),
                    DateFinish = new DateTime(2022, 2, 1),
                    DateBookReturned = null,
                    OverdueFine = 5,
                },
                new BookCheckout()
                {
                    BookCopyId = 11,
                    ReaderId = 1,
                    DateStart = new DateTime(2021, 12, 1),
                    DateFinish = new DateTime(2022, 3, 1),
                    DateBookReturned = null,
                    OverdueFine = 5,
                },
                new BookCheckout()
                {
                    BookCopyId = 12,
                    ReaderId = 2,
                    DateStart = new DateTime(2021, 10, 15),
                    DateFinish = new DateTime(2022, 1, 15),
                    DateBookReturned = null,
                    OverdueFine = 5,
                },
                new BookCheckout()
                {
                    BookCopyId = 13,
                    ReaderId = 3,
                    DateStart = new DateTime(2021, 11, 16),
                    DateFinish = new DateTime(2022, 2, 16),
                    DateBookReturned = new DateTime(2022, 1, 10),
                    OverdueFine = 5,
                },
                new BookCheckout()
                {
                    BookCopyId = 14,
                    ReaderId = 4,
                    DateStart = new DateTime(2021, 12, 4),
                    DateFinish = new DateTime(2022, 3, 1),
                    DateBookReturned = null,
                    OverdueFine = 5,
                },
                new BookCheckout()
                {
                    BookCopyId = 15,
                    ReaderId = 5,
                    DateStart = new DateTime(2021, 12, 7),
                    DateFinish = new DateTime(2022, 3, 7),
                    DateBookReturned = null,
                    OverdueFine = 5,
                },
            };



            private readonly ICollection<MoneyTransaction> moneyTransactions = new MoneyTransaction[] 
            {
                new MoneyTransaction()
                {
                    Id = 1,
                    AmountOfMoney = 508,
                    Date = new DateTime(2021, 5, 1),
                    MoneyTransactionTypeId = 1,
                    BookCopyId = 1,
                    ReaderId = null,
                },
                new MoneyTransaction()
                {
                    Id = 2,
                    AmountOfMoney = 508,
                    Date = new DateTime(2021, 5, 1),
                    MoneyTransactionTypeId = 1,
                    BookCopyId = 2,
                    ReaderId = null,
                },
                new MoneyTransaction()
                {
                    Id = 3,
                    AmountOfMoney = 508,
                    Date = new DateTime(2021, 6, 1),
                    MoneyTransactionTypeId = 1,
                    BookCopyId = 3,
                    ReaderId = null,
                },
                new MoneyTransaction()
                {
                    Id = 4,
                    AmountOfMoney = 508,
                    Date = new DateTime(2021, 6, 1),
                    MoneyTransactionTypeId = 1,
                    BookCopyId = 4,
                    ReaderId = null,
                },
                new MoneyTransaction()
                {
                    Id = 5,
                    AmountOfMoney = 508,
                    Date = new DateTime(2021, 7, 1),
                    MoneyTransactionTypeId = 1,
                    BookCopyId = 5,
                    ReaderId = null,
                },
                new MoneyTransaction()
                {
                    Id = 6,
                    AmountOfMoney = 508,
                    Date = new DateTime(2021, 7, 1),
                    MoneyTransactionTypeId = 1,
                    BookCopyId = 6,
                    ReaderId = null,
                },
                new MoneyTransaction()
                {
                    Id = 7,
                    AmountOfMoney = 640,
                    Date = new DateTime(2021, 8, 1),
                    MoneyTransactionTypeId = 1,
                    BookCopyId = 7,
                    ReaderId = null,
                },
                new MoneyTransaction()
                {
                    Id = 8,
                    AmountOfMoney = 640,
                    Date = new DateTime(2021, 8, 1),
                    MoneyTransactionTypeId = 1,
                    BookCopyId = 8,
                    ReaderId = null,
                },
                new MoneyTransaction()
                {
                    Id = 9,
                    AmountOfMoney = 730,
                    Date = new DateTime(2021, 9, 1),
                    MoneyTransactionTypeId = 1,
                    BookCopyId = 9,
                    ReaderId = null,
                },
                new MoneyTransaction()
                {
                    Id = 10,
                    AmountOfMoney = 730,
                    Date = new DateTime(2021, 9, 1),
                    MoneyTransactionTypeId = 1,
                    BookCopyId = 10,
                    ReaderId = null,
                },
                new MoneyTransaction()
                {
                    Id = 11,
                    AmountOfMoney = 640,
                    Date = new DateTime(2021, 10, 1),
                    MoneyTransactionTypeId = 1,
                    BookCopyId = 11,
                    ReaderId = null,
                },
                new MoneyTransaction()
                {
                    Id = 12,
                    AmountOfMoney = 640,
                    Date = new DateTime(2021, 10, 1),
                    MoneyTransactionTypeId = 1,
                    BookCopyId = 12,
                    ReaderId = null,
                },
                new MoneyTransaction()
                {
                    Id = 13,
                    AmountOfMoney = 640,
                    Date = new DateTime(2021, 11, 1),
                    MoneyTransactionTypeId = 1,
                    BookCopyId = 13,
                    ReaderId = null,
                },
                new MoneyTransaction()
                {
                    Id = 14,
                    AmountOfMoney = 656,
                    Date = new DateTime(2021, 12, 1),
                    MoneyTransactionTypeId = 1,
                    BookCopyId = 14,
                    ReaderId = null,
                },
                new MoneyTransaction()
                {
                    Id = 15,
                    AmountOfMoney = 182,
                    Date = new DateTime(2022, 1, 1),
                    MoneyTransactionTypeId = 1,
                    BookCopyId = 15,
                    ReaderId = null,
                },
                new MoneyTransaction()
                {
                    Id = 16,
                    AmountOfMoney = 10,
                    Date = new DateTime(2021, 12, 19),
                    MoneyTransactionTypeId = 2,
                    BookCopyId = 4,
                    ReaderId = 4,
                },
                new MoneyTransaction()
                {
                    Id = 17,
                    AmountOfMoney = 15,
                    Date = new DateTime(2022, 3, 12),
                    MoneyTransactionTypeId = 2,
                    BookCopyId = 7,
                    ReaderId = 2,
                },
            };
    }
} 
   
