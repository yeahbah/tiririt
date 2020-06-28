using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tiririt.App.Service;
using Tiririt.Core.Collection;
using Tiririt.Web.Common;
using Tiririt.Web.Models;
using Tiririt.Web.Models.Mappings;

namespace Tiririt.Web.Controllers
{
    public class StockQuoteController : TiriritControllerBase
    {
        private readonly IStockQuoteService stockQuoteService;
        
        public StockQuoteController(IStockQuoteService stockQuoteService)
        {
            this.stockQuoteService = stockQuoteService;
        }

        //[HttpGet(RouteConsts.StockQuote.EndOfDay)]
        //public async Task<ActionResult<PagingResultEnvelope<StockQuoteViewModel>>> GetStockQuotes(string symbol, PagingParam pagingParam)
        //{
        //    var pagedResult = await stockQuoteService
        //        .GetStockQuotes(symbol, pagingParam);
        //    var data = pagedResult
        //        .Data.Select(q => q.ToViewModel())
        //        .ToList();

        //    return OkOrNotFoundOf(new PagingResultEnvelope<StockQuoteViewModel>(data, pagedResult.TotalCount, pagingParam));
        //}

        [HttpGet(RouteConsts.StockQuote.EndOfDay)]
        public async Task<ActionResult<IEnumerable<StockQuoteViewModel>>> GetStockQuotes(string symbol)
        {
            var result = await stockQuoteService
                .GetStockQuotes(symbol);

            return Ok(result.Select(q => q.ToViewModel()));
        }

        [HttpGet(RouteConsts.StockQuote.EndOfDayChart)]
        public async Task<ActionResult<IEnumerable<ChartSeriesModel>>> GetChartData(string symbol)
        {
            var quotes = await stockQuoteService
                .GetStockQuotes(symbol);
            if (!quotes.Any()) return NotFound();

            var result = quotes.Select(q => new ChartSeriesModel
            {
                Time = q.TradeDate,
                Value = q.Close
            });

            return Ok(result);
        }
    }
}