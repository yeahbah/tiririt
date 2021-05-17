using Tiririt.Domain.Models;
using Tiririt.Core.Collection;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace Tiririt.Data.Service
{
    public interface IStockQuoteRepository
    {
        Task<StockQuoteModel> AddStockQuote(StockQuoteModel stockQuote, CancellationToken cancellationToken = default);
        Task<PagingResultEnvelope<StockQuoteModel>> GetStockQuotes(string symbol, PagingParam pagingParam, CancellationToken cancellationToken = default);
        Task<IEnumerable<StockQuoteModel>> GetStockQuotes(string symbol, CancellationToken cancellationToken = default);
    }
}