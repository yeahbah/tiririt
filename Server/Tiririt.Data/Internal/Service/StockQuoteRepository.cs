using Tiririt.Data.Entities;
using Tiririt.Data.Service;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Internal.Service
{
    internal class StockQuoteRepository : IStockQuoteRepository
    {
        private readonly TiriritDbContext dbContext;

        public StockQuoteRepository(TiriritDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public StockQuoteModel AddStockQuote(StockQuoteModel stockQuote)
        {
            var quote = new STOCK_QUOTE 
            {
                HIGH = stockQuote.High,
                CLOSE = stockQuote.Close,
                LOW = stockQuote.Low,
                NET_FOREIGN_BUY = stockQuote.NetForeignBuy,
                OPEN = stockQuote.Open,
                STOCK_ID = stockQuote.StockId,
                TRADE_DATE = stockQuote.TradeDate
            };
            dbContext.StockQuotes.Add(quote);
            dbContext.SaveChanges();
            stockQuote.StockQuoteId = quote.STOCK_ID;
            return stockQuote;
        }
    }
}