using System;

namespace Tiririt.App.Models
{
    public class StockQuoteViewModel
    {
        public int StockQuoteId { get; set; }
        public int StockId { get; set; }
        public string Symbol { get; set; }
        public DateTime TradeDate { get; set; }

        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }
        public decimal? NetForeignBuy { get; set; }        
    }
}