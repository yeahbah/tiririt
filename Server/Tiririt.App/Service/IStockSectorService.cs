using Tiririt.Domain.Models;

namespace Tiririt.App.Service
{
    public interface IStockSectorService
    {
        StockSectorModel AddSector(StockSectorModel sector);
    }
}