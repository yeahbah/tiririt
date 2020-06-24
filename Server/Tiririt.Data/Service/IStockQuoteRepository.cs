using Tiririt.Domain.Models;
using Tiririt.Core.Collection;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tiririt.Data.Service
{
    public interface IStockQuoteRepository
    {
        Task<StockQuoteModel> AddStockQuote(StockQuoteModel stockQuote);
        Task<PagingResultEnvelope<StockQuoteModel>> GetStockQuotes(string symbol, PagingParam pagingParam);
        Task<IEnumerable<StockQuoteModel>> GetStockQuotes(string symbol);
    }
}