using Tiririt.Domain.Models;

namespace Tiririt.Data.Service
{
    public interface IStockSectorRepository 
    {
        StockSectorModel AddSector(StockSectorModel sectorModel);
    }
}