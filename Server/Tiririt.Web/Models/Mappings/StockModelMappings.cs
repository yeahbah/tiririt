using System;
using System.Linq;
using Tiririt.Domain.Models;

namespace Tiririt.Web.Models.Mappings
{
    internal static class StockModelMapping
    {
        public static StockViewModel ToViewModel(this StockModel value)
        {
            if (value == null) return null;

            var lastTwoTrades = value.StockQuotes.OrderByDescending(o => o.TradeDate)
                .Take(2);
            var lastTrade = lastTwoTrades.FirstOrDefault();
            var previousTrade = lastTwoTrades.Skip(1).FirstOrDefault();
            return new StockViewModel
            {
                Name = value.Name,
                SectorId = value.SectorId,
                StockId = value.StockId,
                Symbol = value.Symbol,
                LastTradePrice = lastTrade.Close,
                High = lastTrade?.High,
                LastTradeDate = lastTrade.TradeDate,
                PreviousClose = previousTrade.Close,
                Low = lastTrade?.Low,
                NetForeignBuy = lastTrade?.NetForeignBuy,
                Open = lastTrade?.Open,
                IsWatchedByUser = false,
                WatchersCount = value.Wacthers.Count(),
                Volume = lastTrade.Volume,
                PointsChange = lastTrade.Close - previousTrade.Close,
                PercentChange = Math.Round(((lastTrade.Close - previousTrade.Close) / previousTrade.Close) * 100, 2)
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