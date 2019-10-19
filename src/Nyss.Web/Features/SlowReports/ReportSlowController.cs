using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nyss.Web.Features.Report;
using Nyss.Web.Features.SlowReports.Logic;

namespace Nyss.Web.Features.SlowReports
{
    public class ReportSlowController : Controller
    {
        private readonly IReportService _reportService;

        public ReportSlowController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetReports([FromBody] PaginationOptionsDto paginationOptions)
        {
            var options = new PaginationOptions
            {
                Start = paginationOptions.Start,
                Count = paginationOptions.Length
            };

            if (paginationOptions.Order.Length > 0)
            {
                var orderColumnIndex = paginationOptions.Order[0].Column;
                options.Order = paginationOptions.Columns[orderColumnIndex].Data;
                options.OrderAsc = paginationOptions.Order[0].Dir == "asc";
            }

            foreach (var column in paginationOptions.Columns.Where(x => x.Data != null))
            {
                options.SearchDictionary.Add(column.Data, column.Search.Value);
            }

            var paginationResult = await _reportService.GetReportsAsync(options);

            var dataTableData = new DatatableDto<ReportViewModel>
            {
                Draw = paginationOptions.Draw,
                RecordsTotal = paginationResult.TotalCount,
                Data = paginationResult.Data,
                RecordsFiltered = paginationResult.FilteredCount
            };

            return Json(dataTableData);
        }
    }
}