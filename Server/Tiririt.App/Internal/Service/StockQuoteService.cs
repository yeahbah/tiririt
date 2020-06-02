using System.Threading.Tasks;
using Tiririt.App.Service;
using Tiririt.Core.Collection;
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
        public async Task<StockQuoteModel> AddStockQuote(StockQuoteModel stockQuote)
        {
            return await stockQuoteRepository.AddStockQuote(stockQuote);
        }

        public async Task<PagingResultEnvelope<StockQuoteModel>> GetStockQuotes(string symbol, PagingParam pagingParam)
        {
            return await stockQuoteRepository.GetStockQuotes(symbol, pagingParam);
        }
    }
}