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
            if (!context.MoneyTransactionTypes.Any())
            {
                ICollection<MoneyTransactionType> moneyTransactionTypes = new MoneyTransactionType[] 
                {
                    new MoneyTransactionType()
                    { 
                        Name = "Покупка библиотекой книги",
                    },
                    new MoneyTransactionType()
                    { 
                        Name = "Оплата штрафа за просроченную книгу",
                    },
                };
                context.MoneyTransactionTypes.AddRange(moneyTransactionTypes);
                context.SaveChanges();

                ICollection<Genre> genres = new Genre[] 
                {
                    new Genre()
                    {
                        Name = "Другое",
                    },
                    new Genre()
                    {
                        Name = "Для детей",
                    },
                    new Genre()
                    {
                        Name = "Фантастика",
                    },
                    new Genre()
                    {
                        Name = "Классика",
                    },
                };
                context.Genres.AddRange(genres);
                context.SaveChanges();
         
                ICollection<Country> countries = new Country[] 
                {
                    new Country()
                    {
                        Name = "Другое",
                    },
                    new Country()
                    {
                        Name = "Россия",
                    },
                    new Country()
                    {
                        Name = "Великобритания",
                    },
                    new Country()
                    {
                        Name = "США",
                    },
                };
                context.Countries.AddRange(countries);
                context.SaveChanges();
       
                ICollection<Publisher> publishers = new Publisher[] 
                {
                    new Publisher()
                    {
                        Name = "Другое",
                        CountryId = countries.ElementAt(0).Id,
                    },
                    new Publisher()
                    {
                        Name = "Махаон",
                        CountryId = countries.ElementAt(1).Id,
                    },
                    new Publisher()
                    {
                        Name = "АСТ",
                        CountryId = countries.ElementAt(1).Id,
                    },
                };
                context.Publishers.AddRange(publishers);
                context.SaveChanges();
            
                ICollection<Reader> readers = new Reader[] 
                {
                    new Reader()
                    {
                        Name = "Волков Семён Артурович",
                        Email = "volkov@gmail.com",
                        Passport = "4656 172296",
                    },
                    new Reader()
                    {
                        Name = "Тарасов Александр Маркович",
                        Email = "tarasov@gmail.com",
                        Passport = "4714 166528",
                    },
                    new Reader()
                    {
                        Name = "Кукушкина Яна Артемьевна",
                        Email = "kukushkina@gmail.com",
                        Passport = "4850 435532",
                    },
                    new Reader()
                    {
                        Name = "Виноградов Иван Данилович",
                        Email = "vinogradov@gmail.com",
                        Passport = "4546 853306",
                    },
                    new Reader()
                    {
                        Name = "Сазонова Анна Платоновна",
                        Email = "sazonova@gmail.com",
                        Passport = "4336 285466",
                    },
                };
                context.Readers.AddRange(readers);
                context.SaveChanges();
    
                ICollection<Author> authors = new Author[] 
                {
                    new Author()
                    {
                        FullName = "Джоан Роулинг",
                        ShortName = "Дж. К. Роулинг",
                        CountryId = countries.ElementAt(2).Id,
                    },
                    new Author()
                    {
                        FullName = "Фрэнк Герберт",
                        ShortName = "Ф. Герберт",
                        CountryId = countries.ElementAt(3).Id,
                    },
                    new Author()
                    {
                        FullName = "Илья Арнольдович Ильф",
                        ShortName = "И. А. Ильф",
                        CountryId = countries.ElementAt(1).Id,
                    },
                    new Author()
                    {
                        FullName = "Евгений Петров",
                        ShortName = "Е. Петров",
                        CountryId = countries.ElementAt(1).Id,
                    },
                };
                context.Authors.AddRange(authors);
                context.SaveChanges();
           
                ICollection<Book> books = new Book[] 
                {
                    new Book()
                    {
                        Name = "Гарри Поттер и философский камень",
                        NumberOfPages = 432,
                        PublishmentYear = 2014,
                        Price = 508,
                        GenreId = genres.ElementAt(1).Id,
                        PublisherId = 2,
                        Authors = new Author[]{ authors.ElementAt(0)}
                    },
                        new Book()
                        {
                            Name = "Гарри Поттер и Тайная комната",
                            NumberOfPages = 480,
                            PublishmentYear = 2014,
                            Price = 508,
                            GenreId = genres.ElementAt(1).Id,
                            PublisherId = publishers.ElementAt(1).Id,
                            Authors = new Author[]{ authors.ElementAt(0)}
                        },
                        new Book()
                        {
                            Name = "Гарри Поттер и узник Азкабана",
                            NumberOfPages = 528,
                            PublishmentYear = 2014,
                            Price = 508,
                            GenreId = genres.ElementAt(1).Id,
                            PublisherId = publishers.ElementAt(1).Id,
                            Authors = new Author[]{ authors.ElementAt(0)}
                        },
                        new Book()
                        {
                            Name = "Гарри Поттер и Кубок Огня",
                            NumberOfPages = 704,
                            PublishmentYear = 2015,
                            Price = 640,
                            GenreId = genres.ElementAt(1).Id,
                            PublisherId = publishers.ElementAt(1).Id,
                            Authors = new Author[]{ authors.ElementAt(0)}
                        },
                        new Book()
                        {
                            Name = "Гарри Поттер и Орден Феникса",
                            NumberOfPages = 896,
                            PublishmentYear = 2015,
                            Price = 730,
                            GenreId = genres.ElementAt(1).Id,
                            PublisherId = publishers.ElementAt(1).Id,
                            Authors = new Author[]{ authors.ElementAt(0)}
                        },
                        new Book()
                        {
                            Name = "Гарри Поттер и Принц-полукровка",
                            NumberOfPages = 672,
                            PublishmentYear = 2015,
                            Price = 640,
                            GenreId = genres.ElementAt(1).Id,
                            PublisherId = publishers.ElementAt(1).Id,
                            Authors = new Author[]{ authors.ElementAt(0)}
                        },
                        new Book()
                        {
                            Name = "Гарри Поттер и Дары смерти",
                            NumberOfPages = 704,
                            PublishmentYear = 2015,
                            Price = 640,
                            GenreId = genres.ElementAt(1).Id,
                            PublisherId = publishers.ElementAt(1).Id,
                            Authors = new Author[]{ authors.ElementAt(0)}
                        },
                        new Book()
                        {
                            Name = "Дюна",
                            NumberOfPages = 704,
                            PublishmentYear = 2013,
                            Price = 656,
                            GenreId = genres.ElementAt(2).Id,
                            PublisherId = publishers.ElementAt(2).Id,
                            Authors = new Author[]{ authors.ElementAt(1)}
                        },
                        new Book()
                        {
                            Name = "12 стульев",
                            NumberOfPages = 448,
                            PublishmentYear = 2012,
                            Price = 182,
                            GenreId = genres.ElementAt(2).Id,
                            PublisherId = publishers.ElementAt(2).Id,
                            Authors = new Author[]{ authors.ElementAt(2), authors.ElementAt(3)}
                        },
                };
                context.Books.AddRange(books);
                context.SaveChanges();
          
                ICollection<BookCopy> bookCopies = new BookCopy[] 
                {
                    new BookCopy()
                    {
                        BookId = books.ElementAt(0).Id,
                        ReaderId = readers.ElementAt(0).Id,
                    },
                    new BookCopy()
                    {
                        BookId = books.ElementAt(0).Id,
                        ReaderId = null,
                    },
                    new BookCopy()
                    {
                        BookId = books.ElementAt(1).Id,
                        ReaderId = readers.ElementAt(1).Id,
                    },
                    new BookCopy()
                    {
                        BookId = books.ElementAt(1).Id,
                        ReaderId = null,
                    },
                    new BookCopy()
                    {
                        BookId = books.ElementAt(2).Id,
                        ReaderId = null,
                    },
                    new BookCopy()
                    {
                        BookId = books.ElementAt(2).Id,
                        ReaderId = null,
                    },
                    new BookCopy()
                    {
                        BookId = books.ElementAt(3).Id,
                        ReaderId = null,
                    },
                    new BookCopy()
                    {
                        BookId = books.ElementAt(3).Id,
                        ReaderId = null,
                    },
                    new BookCopy()
                    {
                        BookId = books.ElementAt(4).Id,
                        ReaderId = null,
                    },
                    new BookCopy()
                    {
                        BookId = books.ElementAt(4).Id,
                        ReaderId = null,
                    },
                    new BookCopy()
                    {
                        BookId = books.ElementAt(5).Id,
                        ReaderId = null,
                    },
                    new BookCopy()
                    {
                        BookId = books.ElementAt(5).Id,
                        ReaderId = null,
                    },
                    new BookCopy()
                    {
                        BookId = books.ElementAt(6).Id,
                        ReaderId = readers.ElementAt(2).Id,
                    },
                    new BookCopy()
                    {
                        BookId = books.ElementAt(7).Id,
                        ReaderId = null,
                    },
                    new BookCopy()
                    {
                        BookId = books.ElementAt(8).Id,
                        ReaderId = null,
                    },
                };
                context.BookCopies.AddRange(bookCopies);
                context.SaveChanges();
          
                ICollection<BookCheckout> bookCheckouts = new BookCheckout[] 
                {
                    new BookCheckout()
                    {
                        BookCopyId = bookCopies.ElementAt(0).Id,
                        ReaderId = readers.ElementAt(0).Id,
                        DateStart = new DateTime(2021, 6, 5),
                        DateFinish = new DateTime(2021, 8, 5),
                        DateBookReturned = new DateTime(2021, 8, 3),
                        OverdueFine = 5,
                    },
                    new BookCheckout()
                    {
                        BookCopyId = bookCopies.ElementAt(1).Id,
                        ReaderId = readers.ElementAt(1).Id,
                        DateStart = new DateTime(2021, 7, 21),
                        DateFinish = new DateTime(2021, 10, 21),
                        DateBookReturned = new DateTime(2021, 10, 19),
                        OverdueFine = 5,
                    },
                    new BookCheckout()
                    {
                        BookCopyId = bookCopies.ElementAt(2).Id,
                        ReaderId = readers.ElementAt(2).Id,
                        DateStart = new DateTime(2021, 8, 12),
                        DateFinish = new DateTime(2021, 11, 12),
                        DateBookReturned = new DateTime(2021, 11, 10),
                        OverdueFine = 5,
                    },
                    new BookCheckout()
                    {
                        BookCopyId = bookCopies.ElementAt(3).Id,
                        ReaderId = readers.ElementAt(3).Id,
                        DateStart = new DateTime(2021, 9, 17),
                        DateFinish = new DateTime(2021, 12, 17),
                        DateBookReturned =  new DateTime(2021, 12, 19),
                        OverdueFine = 5,
                    },
                    new BookCheckout()
                    {
                        BookCopyId = bookCopies.ElementAt(4).Id,
                        ReaderId = readers.ElementAt(4).Id,
                        DateStart = new DateTime(2021, 10, 15),
                        DateFinish = new DateTime(2022, 1, 15),
                        DateBookReturned = new DateTime(2022, 1, 10),
                        OverdueFine = 5,
                    },
                    new BookCheckout()
                    {
                        BookCopyId = bookCopies.ElementAt(5).Id,
                        ReaderId = readers.ElementAt(0).Id,
                        DateStart = new DateTime(2021, 11, 23),
                        DateFinish = new DateTime(2022, 2, 23),
                        DateBookReturned = null,
                        OverdueFine = 5,
                    },
                    new BookCheckout()
                    {
                        BookCopyId = bookCopies.ElementAt(6).Id,
                        ReaderId = readers.ElementAt(1).Id,
                        DateStart = new DateTime(2021, 12, 9),
                        DateFinish = new DateTime(2022, 3, 9),
                        DateBookReturned = new DateTime(2022, 3, 12),
                        OverdueFine = 5,
                    },
                    new BookCheckout()
                    {
                        BookCopyId = bookCopies.ElementAt(7).Id,
                        ReaderId = readers.ElementAt(2).Id,
                        DateStart = new DateTime(2021, 9, 3),
                        DateFinish = new DateTime(2021, 12, 3),
                        DateBookReturned = null,
                        OverdueFine = 5,
                    },
                    new BookCheckout()
                    {
                        BookCopyId = bookCopies.ElementAt(8).Id,
                        ReaderId = readers.ElementAt(3).Id,
                        DateStart = new DateTime(2021, 10, 18),
                        DateFinish = new DateTime(2022, 1, 18),
                        DateBookReturned = null,
                        OverdueFine = 5,
                    },
                    new BookCheckout()
                    {
                        BookCopyId = bookCopies.ElementAt(9).Id,
                        ReaderId = readers.ElementAt(4).Id,
                        DateStart = new DateTime(2021, 11, 1),
                        DateFinish = new DateTime(2022, 2, 1),
                        DateBookReturned = null,
                        OverdueFine = 5,
                    },
                    new BookCheckout()
                    {
                        BookCopyId = bookCopies.ElementAt(10).Id,
                        ReaderId = readers.ElementAt(0).Id,
                        DateStart = new DateTime(2021, 12, 1),
                        DateFinish = new DateTime(2022, 3, 1),
                        DateBookReturned = null,
                        OverdueFine = 5,
                    },
                    new BookCheckout()
                    {
                        BookCopyId = bookCopies.ElementAt(11).Id,
                        ReaderId = readers.ElementAt(1).Id,
                        DateStart = new DateTime(2021, 10, 15),
                        DateFinish = new DateTime(2022, 1, 15),
                        DateBookReturned = null,
                        OverdueFine = 5,
                    },
                    new BookCheckout()
                    {
                        BookCopyId = bookCopies.ElementAt(12).Id,
                        ReaderId = readers.ElementAt(2).Id,
                        DateStart = new DateTime(2021, 11, 16),
                        DateFinish = new DateTime(2022, 2, 16),
                        DateBookReturned = new DateTime(2022, 1, 10),
                        OverdueFine = 5,
                    },
                    new BookCheckout()
                    {
                        BookCopyId = bookCopies.ElementAt(13).Id,
                        ReaderId = readers.ElementAt(3).Id,
                        DateStart = new DateTime(2021, 12, 4),
                        DateFinish = new DateTime(2022, 3, 1),
                        DateBookReturned = null,
                        OverdueFine = 5,
                    },
                    new BookCheckout()
                    {
                        BookCopyId = bookCopies.ElementAt(14).Id,
                        ReaderId = readers.ElementAt(4).Id,
                        DateStart = new DateTime(2021, 12, 7),
                        DateFinish = new DateTime(2022, 3, 7),
                        DateBookReturned = null,
                        OverdueFine = 5,
                    },
                };
                context.BookCheckouts.AddRange(bookCheckouts);
                context.SaveChanges();
          
                ICollection<MoneyTransaction> moneyTransactions = new MoneyTransaction[] 
                {
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 508,
                        Date = new DateTime(2021, 5, 1),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(0).Id,
                        BookCopyId = bookCopies.ElementAt(0).Id,
                        ReaderId = null,
                    },
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 508,
                        Date = new DateTime(2021, 5, 1),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(0).Id,
                        BookCopyId = bookCopies.ElementAt(1).Id,
                        ReaderId = null,
                    },
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 508,
                        Date = new DateTime(2021, 6, 1),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(0).Id,
                        BookCopyId = bookCopies.ElementAt(2).Id,
                        ReaderId = null,
                    },
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 508,
                        Date = new DateTime(2021, 6, 1),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(0).Id,
                        BookCopyId = bookCopies.ElementAt(3).Id,
                        ReaderId = null,
                    },
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 508,
                        Date = new DateTime(2021, 7, 1),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(0).Id,
                        BookCopyId = bookCopies.ElementAt(4).Id,
                        ReaderId = null,
                    },
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 508,
                        Date = new DateTime(2021, 7, 1),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(0).Id,
                        BookCopyId = bookCopies.ElementAt(5).Id,
                        ReaderId = null,
                    },
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 640,
                        Date = new DateTime(2021, 8, 1),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(0).Id,
                        BookCopyId = bookCopies.ElementAt(6).Id,
                        ReaderId = null,
                    },
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 640,
                        Date = new DateTime(2021, 8, 1),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(0).Id,
                        BookCopyId = bookCopies.ElementAt(7).Id,
                        ReaderId = null,
                    },
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 730,
                        Date = new DateTime(2021, 9, 1),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(0).Id,
                        BookCopyId = bookCopies.ElementAt(8).Id,
                        ReaderId = null,
                    },
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 730,
                        Date = new DateTime(2021, 9, 1),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(0).Id,
                        BookCopyId = bookCopies.ElementAt(9).Id,
                        ReaderId = null,
                    },
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 640,
                        Date = new DateTime(2021, 10, 1),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(0).Id,
                        BookCopyId = bookCopies.ElementAt(10).Id,
                        ReaderId = null,
                    },
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 640,
                        Date = new DateTime(2021, 10, 1),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(0).Id,
                        BookCopyId = bookCopies.ElementAt(11).Id,
                        ReaderId = null,
                    },
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 640,
                        Date = new DateTime(2021, 11, 1),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(0).Id,
                        BookCopyId = bookCopies.ElementAt(12).Id,
                        ReaderId = null,
                    },
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 656,
                        Date = new DateTime(2021, 12, 1),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(0).Id,
                        BookCopyId = bookCopies.ElementAt(13).Id,
                        ReaderId = null,
                    },
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 182,
                        Date = new DateTime(2022, 1, 1),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(0).Id,
                        BookCopyId = bookCopies.ElementAt(14).Id,
                        ReaderId = null,
                    },
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 10,
                        Date = new DateTime(2021, 12, 19),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(1).Id,
                        BookCopyId = bookCopies.ElementAt(3).Id,
                        ReaderId = readers.ElementAt(3).Id,
                    },
                    new MoneyTransaction()
                    {
                        AmountOfMoney = 15,
                        Date = new DateTime(2022, 3, 12),
                        MoneyTransactionTypeId = moneyTransactionTypes.ElementAt(1).Id,
                        BookCopyId = bookCopies.ElementAt(6).Id,
                        ReaderId = readers.ElementAt(1).Id,
                    },
                };
                context.MoneyTransactions.AddRange(moneyTransactions);
                context.SaveChanges();
            }
        }
    }
}
