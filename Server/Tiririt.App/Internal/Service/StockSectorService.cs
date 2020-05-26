using Tiririt.App.Service;
using Tiririt.Data.Service;
using Tiririt.Domain.Models;

namespace Tiririt.App.Internal.Service
{
    public class StockSectorService : IStockSectorService
    {
        private readonly IStockSectorRepository stockSectorRepository;

        public StockSectorService(IStockSectorRepository stockSectorRepository)
        {
            this.stockSectorRepository = stockSectorRepository;
        }
        public StockSectorModel AddSector(StockSectorModel sector)
        {
            return stockSectorRepository.AddSector(sector);
        }
    }
}