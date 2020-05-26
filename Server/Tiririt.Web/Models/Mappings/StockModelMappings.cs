using Tiririt.Domain.Models;

namespace Tiririt.Web.Models.Mappings
{
    internal static class StockModelMapping
    {
        public static StockViewModel ToViewModel(this StockModel value)
        {
            if (value == null) return null;

            return new StockViewModel
            {
                Name = value.Name,
                SectorId = value.SectorId,
                StockId = value.StockId,
                Symbol = value.Symbol                
            };
            
        }

        public static StockModel ToDomainModel(this StockViewModel value)
        {
            if (value == null) return null;

            return new StockModel
            {
                Name = value.Name,
                SectorId = value.SectorId,
                StockId = value.StockId,
                Symbol = value.Symbol
            };
        }
    }
}