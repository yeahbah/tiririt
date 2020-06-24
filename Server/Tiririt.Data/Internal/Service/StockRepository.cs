using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tiririt.Data.Service;
using Tiririt.Data.Internal.Mappings;
using Tiririt.Domain.Models;
using System.Threading.Tasks;
using Tiririt.Data.Entities;
using Tiririt.Core.Identity;

namespace Tiririt.Data.Internal.Service
{
    internal class StockRepository : IStockRepository
    {
        private readonly TiriritDbContext dbContext;
        private readonly ITiriritPostRepository postRepository;
        private readonly ICurrentPrincipal currentPrincipal;

        public StockRepository(TiriritDbContext dbContext, 
            ITiriritPostRepository postRepository,
            ICurrentPrincipal currentPrincipal)
        {
            this.dbContext = dbContext;
            this.postRepository = postRepository;
            this.currentPrincipal = currentPrincipal;
        }
        
        public IQueryable<StockModel> GetAll()
        {
            var result = dbContext.Stocks
                .AsNoTracking()
                .Select(stock => new StockModel
                {
                    Name = stock.NAME,
                    SectorId = stock.SECTOR_ID,
                    StockId = stock.STOCK_ID,
                    Symbol = stock.SYMBOL,
                    StockQuotes = stock.Ref_StockQuotes.Select(q => q.ToDomainModel()),
                    Wacthers = stock.Ref_StocksInWatchLists.Select(w => w.Ref_WatchList.Ref_TiriritUser.ToDomainModel())
                });
            return result;
        }

        public async Task<StockModel> AddStock(StockModel stockModel)
        {
            var stock = new STOCK 
            {                
                SECTOR_ID = stockModel.SectorId,
                NAME = stockModel.Name,
                SYMBOL = stockModel.Symbol
            };
            dbContext.Stocks.Add(stock);
            await dbContext.SaveChangesAsync();
            return await GetStock(stockModel.Symbol);
        }

        public async Task<StockModel> GetStock(string stockSymbol)
        {
            return await GetAll()                
                .SingleOrDefaultAsync(stock => stock.Symbol.ToUpper() == stockSymbol.ToUpper());
        }

        public async Task LinkPostToStocks(int postId, string[] symbols)
        {
            var stocks = await GetAll()                            
                .Where(s => symbols.Contains(s.Symbol))
                .ToListAsync();
            
            foreach(var stock in stocks)
            {                
                var link = new POST_STOCK 
                {
                    TIRIRIT_POST_ID = postId,
                    STOCK_ID = stock.StockId
                };
                dbContext.PostStocks.Add(link);                
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveStockLinksFromPost(int postId, bool permanent = false)
        {
            var stocks = await dbContext.PostStocks
                .Where(p => p.TIRIRIT_POST_ID == postId)
                .ToListAsync();

            if (permanent) 
            {
                stocks
                    .ForEach(p => {
                        dbContext.PostStocks.Remove(p);
                    });
            }
            else
            {
                stocks
                    .ForEach(p => {
                        p.DELETED_IND = 1;
                    });
            }
            await dbContext.SaveChangesAsync();            
        }
    }
}