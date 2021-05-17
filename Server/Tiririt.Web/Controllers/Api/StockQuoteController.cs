using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiririt.App.Models;
using Tiririt.App.Stock.Queries;
using Tiririt.Web.Common;

namespace Tiririt.Web.Controllers
{
    public class StockQuoteController : TiriritControllerBase
    {
        private readonly IMediator mediator;

        public StockQuoteController(IMediator mediator)
        {
            this.mediator = mediator;
        }        

        [HttpGet(RouteConsts.StockQuote.EndOfDay)]
        public async Task<ActionResult<IEnumerable<StockQuoteViewModel>>> GetStockQuotes(string symbol, CancellationToken cancellationToken)
        {
            var result = await this.mediator.Send(new GetStockQuotesQuery(symbol), cancellationToken);
            return Ok(result);                           
        }

        [HttpGet(RouteConsts.StockQuote.EndOfDayChart)]
        public async Task<ActionResult<IEnumerable<ChartSeriesViewModel>>> GetChartData(string symbol, CancellationToken cancellationToken)
        {
            var result = await this.mediator.Send(new GetStockChartDataQuery(symbol), cancellationToken);
            if (!result.Any()) return NotFound();

            return Ok(result);
        }
    }
}