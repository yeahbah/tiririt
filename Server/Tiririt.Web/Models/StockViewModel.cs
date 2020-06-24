using System;

namespace Tiririt.Web.Models
{
    public class StockViewModel 
    {
        public int StockId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int? SectorId { get; set; }

        public DateTime? LastTradeDate { get; set; }
        public decimal? LastTradePrice { get; set; }
        public decimal? Open { get; set; }
        public decimal? High { get; set; }
        public decimal? Low { get; set; }
        public decimal? NetForeignBuy { get; set; }
    }
}