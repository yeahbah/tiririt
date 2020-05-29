using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tiririt.Core.Collection;
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
                TRADE_DATE = stockQuote.TradeDate,
                VOLUMNE = stockQuote.Volume
            };
            dbContext.StockQuotes.Add(quote);
            dbContext.SaveChanges();
            stockQuote.StockQuoteId = quote.STOCK_ID;
            return stockQuote;
        }

        public IQueryable<StockQuoteModel> GetAll()
        {
            var result = dbContext.StockQuotes
                .AsNoTracking()
                .Select(data => new StockQuoteModel {
                    Symbol = data.Ref_Stock.SYMBOL,
                    Close = data.CLOSE,
                    High = data.HIGH,
                    Low = data.LOW,
                    NetForeignBuy = data.NET_FOREIGN_BUY,
                    Open = data.OPEN,
                    StockId = data.Ref_Stock.STOCK_ID,
                    StockQuoteId = data.STOCK_QUOTE_ID,
                    TradeDate = data.TRADE_DATE,
                    Volume = data.VOLUMNE                    
                });
            return result;
        }

        public PagingResultEnvelope<StockQuoteModel> GetStockQuotes(string symbol, PagingParam pagingParam)
        {
            var result = GetAll()
                .Where(quote => quote.Symbol == symbol);
            return PagingResultEnvelope<StockQuoteModel>.ToPagingEnvelope(result, pagingParam).Result;
        }
    }
}