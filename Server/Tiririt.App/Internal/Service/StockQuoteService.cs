using Tiririt.App.Service;
using Tiririt.Data.Service;
using Tiririt.Domain.Models;

namespace Tiririt.App.Internal.Service
{
    internal class StockQuoteService : IStockQuoteService
    {
        private readonly IStockQuoteRepository stockQuoteRepository;

        public StockQuoteService(IStockQuoteRepository stockQuoteRepository)
        {
            this.stockQuoteRepository = stockQuoteRepository;
        }
        public StockQuoteModel AddStockQuote(StockQuoteModel stockQuote)
        {
            return stockQuoteRepository.AddStockQuote(stockQuote);
        }
    }
}