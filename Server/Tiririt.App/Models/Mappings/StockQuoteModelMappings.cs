using Tiririt.Domain.Models;

namespace Tiririt.App.Models.Mappings
{
    public static class StockQuoteModelMapping
    {
        public static StockQuoteViewModel ToViewModel(this StockQuoteModel value)
        {
            if (value == null) return null;
            return new StockQuoteViewModel 
            {
                Close = value.Close,
                High = value.High,
                Low = value.Low,
                NetForeignBuy = value.NetForeignBuy,
                Open = value.Open,
                StockId = value.StockId,
                Symbol = value.Symbol,
                StockQuoteId = value.StockQuoteId,
                TradeDate = value.TradeDate,
                Volume = value.Volume
            };
        }

        
    }
}