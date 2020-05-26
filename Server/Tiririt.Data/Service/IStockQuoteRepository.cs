using Tiririt.Domain.Models;

namespace Tiririt.Data.Service
{
    public interface IStockQuoteRepository
    {
        StockQuoteModel AddStockQuote(StockQuoteModel stockQuote);
    }
}