using BLL.Filters;
using BLL.Interfaces;
using BLL.Services;
using Domain.Entities;
using LibraryPlotnikova.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlotnikova.Controllers
{

    public class StatisticsController : Controller
    {
        private readonly IMoneyTransactionService moneyTransactionService;
        private readonly IBookCheckoutService bookCheckoutService;

        public StatisticsController(IMoneyTransactionService moneyTransactionService, IBookCheckoutService bookCheckoutService)
        {
            this.moneyTransactionService = moneyTransactionService;
            this.bookCheckoutService = bookCheckoutService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveStatistics(StatisticsModel model)
        {
            
           if (model.StatisticsType == "денежные операции")
            {
                return await SaveStatisticsTransactions(model.DateFilter);
            }
                    
            return await SaveStatisticsCheckouts(model.DateFilter);
        }

        private async Task<IActionResult> SaveStatisticsTransactions(DateFilter filter)
        {
            IEnumerable<MoneyTransaction> transactions = (await moneyTransactionService.GetTransactionsByDates(filter))
                .OrderBy(e => e.Date);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Сумма;Тип операции;Книга;Читатель");

            foreach(var item in transactions)
            {
                builder.AppendLine($"{item.AmountOfMoney};{item.MoneyTransactionType.Name};{item.BookCopy.Book?.Name};{item.Reader?.Name}");
            }

            string title = $"transactions {filter.FirstDate.ToShortDateString()} — {filter.LastDate.ToShortDateString()} .txt";
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/plain", title);
        }

        private async Task<IActionResult> SaveStatisticsCheckouts(DateFilter filter)
        {
            var checkoutsToReaders = (await bookCheckoutService.GetBookCheckoutsToReadersByDates(filter))
                .Select(e => new {Date = e.DateStart, BookName = e.BookCopy.Book?.Name, ReaderName = e.Reader?.Name, Type = "Выдача", });

            var checkoutsFromReaders = (await bookCheckoutService.GetBookCheckoutsFromReadersByDates(filter))
                .Select(e => new {Date = e.DateBookReturned.Value, BookName = e.BookCopy.Book?.Name, ReaderName = e.Reader?.Name, Type = "Приём", });

            var checkouts = checkoutsToReaders.ToList();
            checkouts.AddRange(checkoutsFromReaders);
            checkouts = checkouts.OrderBy(e => e.Date).ToList();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Дата;Книга;Читатель;Тип операции");

            foreach(var item in checkouts)
            {
                builder.AppendLine($"{item.Date};{item.BookName};{item.ReaderName};{item.Type}");
            }

            string title = $"checkouts {filter.FirstDate.ToShortDateString()} — {filter.LastDate.ToShortDateString()} .txt";
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/plain", title);
        }
    }
}
