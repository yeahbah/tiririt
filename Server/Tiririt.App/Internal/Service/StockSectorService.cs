using System.Threading.Tasks;
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
        public async Task<StockSectorModel> AddSector(StockSectorModel sector)
        {
            return await stockSectorRepository.AddSector(sector);
        }

        public async Task<StockSectorModel> GetSector(string name)
        {
            return await stockSectorRepository.GetSector(name);
        }
    }
}