using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiririt.App.Models;
using Tiririt.App.Models.Mappings;
using Tiririt.Data.Service;

namespace Tiririt.App.Stock.Queries
{
    public record GetStockQuotesQuery(string StockSymbol) : IRequest<IEnumerable<StockQuoteViewModel>>;

    public class GetStockQuotesQueryHandler : IRequestHandler<GetStockQuotesQuery, IEnumerable<StockQuoteViewModel>>
    {
        private readonly IStockQuoteRepository stockQuoteRepository;

        public GetStockQuotesQueryHandler(IStockQuoteRepository stockQuoteRepository)
        {
            this.stockQuoteRepository = stockQuoteRepository;
        }

        public async Task<IEnumerable<StockQuoteViewModel>> Handle(GetStockQuotesQuery request, CancellationToken cancellationToken)
        {
            var quotes = await this.stockQuoteRepository.GetStockQuotes(request.StockSymbol, cancellationToken);
            return quotes.Select(q => q.ToViewModel());
        }
    }
}
