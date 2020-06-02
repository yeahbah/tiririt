using Tiririt.Domain.Models;
using Tiririt.Core.Collection;
using System.Threading.Tasks;

namespace Tiririt.Data.Service
{
    public interface IStockQuoteRepository
    {
        Task<StockQuoteModel> AddStockQuote(StockQuoteModel stockQuote);
        Task<PagingResultEnvelope<StockQuoteModel>> GetStockQuotes(string symbol, PagingParam pagingParam);
    }
}