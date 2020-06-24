using System.Linq;
using Tiririt.Domain.Models;

namespace Tiririt.Web.Models.Mappings
{
    internal static class StockModelMapping
    {
        public static StockViewModel ToViewModel(this StockModel value)
        {
            if (value == null) return null;

            var lastTrade = value.StockQuotes.OrderByDescending(o => o.TradeDate).FirstOrDefault();
            return new StockViewModel
            {
                Name = value.Name,
                SectorId = value.SectorId,
                StockId = value.StockId,
                Symbol = value.Symbol,
                LastTradePrice = lastTrade?.Close,
                High = lastTrade?.High,
                LastTradeDate = lastTrade?.TradeDate,
                Low = lastTrade?.Low,
                NetForeignBuy = lastTrade?.NetForeignBuy,
                Open = lastTrade?.Open
            };
        }

        //public static StockModel ToDomainModel(this StockViewModel value)
        //{
        //    if (value == null) return null;

        //    return new StockModel
        //    {
        //        Name = value.Name,
        //        SectorId = value.SectorId,
        //        StockId = value.StockId,
        //        Symbol = value.Symbol,
        //        Price = value.Price
        //    };
        //}
    }
}