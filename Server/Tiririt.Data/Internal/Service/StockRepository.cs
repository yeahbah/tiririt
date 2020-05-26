using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tiririt.Data.Service;
using Tiririt.Data.Internal.Mappings;
using Tiririt.Domain.Models;
using System.Threading.Tasks;
using System.IO;
using Tiririt.Data.Entities;

namespace Tiririt.Data.Internal.Service
{
    internal class StockRepository : IStockRepository
    {
        private readonly TiriritDbContext dbContext;

        public StockRepository(TiriritDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public StockModel AddStock(StockModel stockModel)
        {
            var stock = new STOCK 
            {                
                SECTOR_ID = stockModel.SectorId,
                NAME = stockModel.Name,
                SYMBOL = stockModel.Symbol
            };
            dbContext.Stocks.Add(stock);
            dbContext.SaveChanges();
            return GetStock(stockModel.Symbol).Result;
        }

        public async Task<StockModel> GetStock(string stockSymbol)
        {
            var query = await dbContext.Stocks
                .AsNoTracking()
                .Where(stock => stock.SYMBOL == stockSymbol)
                .SingleOrDefaultAsync(stock => stock.SYMBOL == stockSymbol);
                            
            return query.ToDomainModel();
        }

    }
}