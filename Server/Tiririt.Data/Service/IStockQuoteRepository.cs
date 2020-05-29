using Tiririt.Domain.Models;
using Tiririt.Core.Collection;

namespace Tiririt.Data.Service
{
    public interface IStockQuoteRepository
    {
        StockQuoteModel AddStockQuote(StockQuoteModel stockQuote);
        PagingResultEnvelope<StockQuoteModel> GetStockQuotes(string symbol, PagingParam pagingParam);
    }
}