using Tiririt.Domain.Models;

namespace Tiririt.App.Service
{
    public interface IStockQuoteService
    {
        StockQuoteModel AddStockQuote(StockQuoteModel stockQuote);
    }
}