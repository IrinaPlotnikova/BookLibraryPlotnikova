using BLL.Filters;
using BLL.Interfaces;
using LibraryPlotnikova.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<FileResult> SaveStatistics(StatisticsModel model)
        {
            
            if (model.StatisticsType == "денежные операции")
            {
                return await SaveStatisticsTransactions(model.DateFilter);
            }
                    
            return await SaveStatisticsCheckouts(model.DateFilter);
        }

        private async Task<FileResult> SaveStatisticsTransactions(DateFilter filter)
        {
            string format = "yyyy.MM.dd";
            MemoryStream content = await moneyTransactionService.SaveStatisticsAsXlsxFileToMemoryStream(filter);
            return File(
                content.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"transactions {filter.FirstDate.ToString(format)} - {filter.LastDate.ToString(format)}.xlsx"
                );
        }

        private async Task<FileResult> SaveStatisticsCheckouts(DateFilter filter)
        {
            string format = "yyyy.MM.dd";
            MemoryStream content = await bookCheckoutService.SaveStatisticsAsXlsxFileToMemoryStream(filter);
            return File(
                content.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"checkouts {filter.FirstDate.ToString(format)} - {filter.LastDate.ToString(format)}.xlsx"
                );
        }
    }
}
