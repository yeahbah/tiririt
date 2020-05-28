using System.Linq;
using Tiririt.Data.Entities;
using Tiririt.Data.Service;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Internal.Service
{
    internal class StockSectorRepository : IStockSectorRepository
    {
        private readonly TiriritDbContext dbContext;

        public StockSectorRepository(TiriritDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public StockSectorModel AddSector(StockSectorModel sectorModel)
        {
            var sector = new STOCK_SECTOR 
            {
                SECTOR_NAME = sectorModel.SectorName
            };
            dbContext.StockSectors.Add(sector);
            dbContext.SaveChanges();
            return new StockSectorModel { SectorName = sector.SECTOR_NAME, SectorId = sector.STOCK_SECTOR_ID };
        }

        public StockSectorModel GetSector(string name)
        {
            var result = dbContext.StockSectors
                .Where(s => s.SECTOR_NAME == name)
                .Select(s => new StockSectorModel {
                    SectorId = s.STOCK_SECTOR_ID,
                    SectorName = s.SECTOR_NAME
                })                
                .SingleOrDefault();
            return result;
        }
    }
}