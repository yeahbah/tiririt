using System;

namespace Tiririt.Domain.Models
{
    public class StockQuoteModel 
    {
        public int StockQuoteId { get; set; }
        public int StockId { get; set; }
        public DateTime TradeDate { get; set; }

        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }
        public decimal? NetForeignBuy { get; set; }        
    }
}