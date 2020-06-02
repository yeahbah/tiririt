using Tiririt.Data.Entities;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Internal.Mappings
{
    public static class StockQuoteMappings
    {
        public static StockQuoteModel ToDomainModel(this STOCK_QUOTE value)
        {
            if (value == null) return null;

            return new StockQuoteModel
            {
                Close = value.CLOSE,
                High = value.HIGH,
                Low = value.LOW,
                NetForeignBuy = value.NET_FOREIGN_BUY,
                Open = value.OPEN,
                StockId = value.STOCK_ID,
                StockQuoteId = value.STOCK_ID,
                TradeDate = value.TRADE_DATE,
                Volume = value.VOLUMNE
            };
        }
    }
}
