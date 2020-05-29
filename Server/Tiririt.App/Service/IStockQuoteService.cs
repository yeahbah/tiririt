using Tiririt.Core.Collection;
using Tiririt.Domain.Models;

namespace Tiririt.App.Service
{
    public interface IStockQuoteService
    {
        StockQuoteModel AddStockQuote(StockQuoteModel stockQuote);
        PagingResultEnvelope<StockQuoteModel> GetStockQuotes(string symbol, PagingParam pagingParam);        
    }
}