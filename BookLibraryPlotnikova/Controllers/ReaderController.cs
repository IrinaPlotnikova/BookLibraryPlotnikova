using BLL.Filters;
using BLL.Interfaces;
using Domain.Entities;
using LibraryPlotnikova.Models;
using LibraryPlotnikova.Models.ReaderModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPlotnikova.Controllers
{
    public class ReaderController : Controller
    {
        private readonly IReaderService readerService;
        private readonly IBookService bookService;
        private readonly IBookCopyService bookCopyService;
        private readonly IBookCheckoutService bookCheckoutService;
        private readonly IMoneyTransactionService moneyTransactionService;

        public ReaderController(IReaderService readerService, IBookService bookService, IBookCopyService bookCopyService, IBookCheckoutService bookCheckoutService,
                                IMoneyTransactionService moneyTransactionService)
        {
            this.readerService = readerService;
            this.bookService = bookService;
            this.bookCopyService = bookCopyService;
            this.bookCheckoutService = bookCheckoutService;
            this.moneyTransactionService = moneyTransactionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View("Index", await readerService.GetAllReaders());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create", new CreateReaderModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromModel([FromForm] Reader reader)
        {
            if (reader == null || !await VerifyReader(reader))
            {
                return RedirectToAction("Index");
            }

            await readerService.CreateReader(reader);
            return RedirectToAction("Info", new { id = reader.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Reader reader = await readerService.GetReaderById(id);
            if (reader == null)
            {
                 return RedirectToAction("Index");
            }

            UpdateReaderModel model =  new UpdateReaderModel()
            {
                Id = id,
                Name = reader.Name,
                Email = reader.Email,
                Passport = reader.Passport
            };
            return View("Update", model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFromModel([FromForm] Reader readerFromModel)
        {
            if (readerFromModel == null || !await VerifyReader(readerFromModel))
            {
                return RedirectToAction("Index");
            }

            Reader reader = await readerService.GetReaderById(readerFromModel.Id);
            if (reader == null)
            {
                return RedirectToAction("Index");
            }

            reader.Name = readerFromModel.Name;
            reader.Email = readerFromModel.Email;
            reader.Passport = readerFromModel.Passport;
            await readerService.UpdateReader(reader);
            return RedirectToAction("Info", new { id = reader.Id});
        }

        [HttpGet]
        public async Task<IActionResult> DeletionAttempt(int id)
        {
            Reader reader = await readerService.GetReaderById(id);
            if (reader == null)
            {
                return RedirectToAction("Index");
            }
            return View("ConfirmDeletion", reader);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await readerService.GetReaderById(id) != null)
            {
                await readerService.DeleteReader(id);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            Reader reader = await readerService.GetReaderById(id);
            if (reader == null)
            {
                return RedirectToAction("Index");
            }

            InfoReaderModel model = new InfoReaderModel()
            {
                Reader = reader,
                BookCheckoutsCurrent = reader.BookCheckouts.Where(e => e.DateBookReturned == null),
                BookCheckoutsHistory = reader.BookCheckouts.Where(e => e.DateBookReturned != null)
            };
            return View("Info", model);
        }

        [HttpGet]
        public async Task<IActionResult> GiveBooks(int readerId)
        {
            Reader reader = await readerService.GetReaderById(readerId);
            if (reader == null)
            {
                return RedirectToAction("Index");
            }

            GiveBooksModel model = new GiveBooksModel()
            {
                Reader = reader,
                AvailableBooks = (await bookService.GetAvailableBooks()).Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name }),
            };
            return View("GiveBooks", model);
        }

        [HttpPost]
        public async Task<IActionResult> GiveBooks(GiveBooksModel model)
        {
            DateTime dateStart = DateTime.Today;
            DateTime dateFinish = dateStart.AddMonths(3);
            if (await readerService.GetReaderById(model.Reader.Id) == null)
            {
                return RedirectToAction("Index");
            }

            foreach(int bookId in model.SelectedBooksId)
            {
                Book book = await bookService.GetBookById(bookId);
                if (book != null)
                {
                    ICollection<BookCopy> availableBookCopies = await bookCopyService.GetAvailableCopiesByBookId(bookId);
                    if (availableBookCopies.Any())
                    {
                        BookCopy bookCopy = availableBookCopies.ElementAt(0);
                        BookCheckout bookCheckout = new BookCheckout()
                        {
                            BookCopyId = bookCopy.Id,
                            ReaderId = model.Reader.Id,
                            DateStart = dateStart,
                            DateFinish = dateFinish,
                            DateBookReturned = null,
                            OverdueFine = Math.Max(5, (int)(book.Price * 0.01))
                        };
                        bookCopy.BookStatusId = 2;
                        bookCopy.ReaderId = model.Reader.Id;
                        await bookCopyService.UpdateBookCopy(bookCopy);
                        await bookCheckoutService.CreateBookCheckout(bookCheckout);
                    }
                }
            }
            return RedirectToAction("Info", new { id = model.Reader.Id});
        }


        [HttpGet]
        public async Task<IActionResult> TakeBooks(int readerId)
        {
            Reader reader = await readerService.GetReaderById(readerId);
            if (reader == null)
            {
                return RedirectToAction("Index");
            }

            TakeBooksModel model = new TakeBooksModel()
            {
                Reader = reader,
                AvailableBookCheckouts = reader.BookCheckouts.Where(e => e.DateBookReturned == null).Select(e => new SelectListItem() 
                { 
                    Value = e.Id.ToString(), 
                    Text = e.BookCopy.Book.Name + "   "+ ((DateTime.Now - e.DateFinish).Days > 0 ? $"Штраф: {(DateTime.Now - e.DateFinish).Days * e.OverdueFine} р." : "")
                }),
            };
            return View("TakeBooks", model);
        }

        [HttpPost]
        public async Task<IActionResult> TakeBooks(TakeBooksModel model)
        {
            DateTime today = DateTime.Today;
            Reader reader = await readerService.GetReaderById(model.Reader.Id);
            if (reader == null)
            {
                return RedirectToAction("Index");
            }

            foreach(int bookCheckoutId in model.SelectedBookCheckoutsId)
            {
                BookCheckout bookCheckout = await bookCheckoutService.GetBookCheckoutById(bookCheckoutId);
                if (bookCheckout != null)
                {
                    bookCheckout.DateBookReturned = today;
                    await bookCheckoutService.UpdateBookCheckout(bookCheckout);

                    BookCopy bookCopy = bookCheckout.BookCopy;
                    bookCopy.ReaderId = null;
                    bookCopy.BookStatusId = 1;
                    await bookCopyService.UpdateBookCopy(bookCopy);
                
                    if (today > bookCheckout.DateFinish)
                    {
                        int overdueFine = (today - bookCheckout.DateFinish).Days * bookCheckout.OverdueFine;
                        MoneyTransaction moneyTransaction = new MoneyTransaction()
                        {
                            MoneyTransactionTypeId = 2,
                            ReaderId = model.Reader.Id,
                            Date = today,
                            BookCopyId = bookCopy.Id,
                            AmountOfMoney = overdueFine,
                        };
                        await moneyTransactionService.CreateMoneyTransaction(moneyTransaction);
                    }
                }
            }
            return RedirectToAction("Info", new { id = model.Reader.Id});
        }

        private async Task<bool> VerifyReader(Reader reader)
        {
            EmailAddressAttribute emailValidation = new EmailAddressAttribute();
            IEnumerable<int> readersId = (await readerService.GetReadersByPassport(reader.Passport)).Select(r => r.Id);
            return !string.IsNullOrWhiteSpace(reader.Name) && reader.Name.Length <= 150 &&
                !string.IsNullOrWhiteSpace(reader.Passport) && reader.Passport.Length <= 20 &&
                (!readersId.Any() || readersId.Contains(reader.Id)) &&
                !string.IsNullOrWhiteSpace(reader.Email) && reader.Email.Length <= 40 && emailValidation.IsValid(reader.Email);
        }
    }
}
