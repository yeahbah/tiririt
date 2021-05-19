using System;
using Tiririt.Core.CQRS;

namespace Tiririt.App.Models
{
    public record StockViewModel : BaseResponse
    {
        public int StockId { get; init; }
        public string Symbol { get; init; }
        public string Name { get; init; }
        public int? SectorId { get; init; }

        public DateTime? LastTradeDate { get; init; }
        public decimal? LastTradePrice { get; init; }
        public decimal? PreviousClose { get; init; }
        public decimal? Open { get; init; }
        public decimal? High { get; init; }
        public decimal? Low { get; init; }
        public long? Volume { get; init; }
        public decimal? NetForeignBuy { get; init; }

        public bool IsWatchedByUser { get; init; }
        public int WatchersCount { get; init; }
        public decimal PointsChange { get; init; }
        public decimal PercentChange { get; init; }
    }
}
