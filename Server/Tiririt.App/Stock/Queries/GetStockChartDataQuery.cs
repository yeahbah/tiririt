using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiririt.App.Models;
using Tiririt.Data.Service;

namespace Tiririt.App.Stock.Queries
{
    public record GetStockChartDataQuery(string StockSymbol) : IRequest<IEnumerable<ChartSeriesModel>>;

    public class GetStockChartDataQueryHandler : IRequestHandler<GetStockChartDataQuery, IEnumerable<ChartSeriesModel>>
    {
        private readonly IStockQuoteRepository stockQuoteRepository;

        public GetStockChartDataQueryHandler(IStockQuoteRepository stockQuoteRepository)
        {
            this.stockQuoteRepository = stockQuoteRepository;
        }

        public async Task<IEnumerable<ChartSeriesModel>> Handle(GetStockChartDataQuery request, CancellationToken cancellationToken)
        {
            var quotes = await this.stockQuoteRepository.GetStockQuotes(request.StockSymbol, cancellationToken);
            var result = quotes.Select(q => new ChartSeriesModel
            {
                Time = q.TradeDate,
                Value = q.Close
            });
            return result;           
        }
    }
}
