using Tiririt.Data.Entities;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Internal.Mappings
{
    internal static class StockModelMapping
    {
        public static StockModel ToDomainModel(this STOCK value)
        {
            if (value == null)
            {
                return null;
            }

            return new StockModel 
            {
                Name = value.NAME,
                StockId = value.STOCK_ID,
                SectorId = value.SECTOR_ID,
                Symbol = value.SYMBOL
            };
        }
    }
}