using System.Threading.Tasks;
using Tiririt.Core.Collection;
using Tiririt.Domain.Models;

namespace Tiririt.App.Service
{
    public interface IStockQuoteService
    {
        Task<StockQuoteModel> AddStockQuote(StockQuoteModel stockQuote);
        Task<PagingResultEnvelope<StockQuoteModel>> GetStockQuotes(string symbol, PagingParam pagingParam);        
    }
}