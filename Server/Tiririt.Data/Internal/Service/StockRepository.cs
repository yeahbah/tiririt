using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tiririt.Data.Service;
using Tiririt.Data.Internal.Mappings;
using Tiririt.Domain.Models;
using System.Threading.Tasks;
using Tiririt.Data.Entities;

namespace Tiririt.Data.Internal.Service
{
    internal class StockRepository : IStockRepository
    {
        private readonly TiriritDbContext dbContext;
        private readonly ITiriritPostRepository postRepository;

        public StockRepository(TiriritDbContext dbContext, ITiriritPostRepository postRepository)
        {
            this.dbContext = dbContext;
            this.postRepository = postRepository;
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

        public void LinkPostToStocks(int postId, string[] symbols)
        {
            var stocks = dbContext.Stocks                            
                .Where(s => symbols.Contains(s.SYMBOL));
            
            foreach(var stock in stocks)
            {                
                var link = new POST_STOCK 
                {
                    TIRIRIT_POST_ID = postId,
                    Ref_Stock = stock
                };
                dbContext.PostStocks.Add(link);                
            }
            dbContext.SaveChanges();
        }

        public void RemoveStockLinksFromPost(int postId)
        {
            dbContext.PostStocks
                .Where(p => p.TIRIRIT_POST_ID == postId)
                .ToList()
                .ForEach(p => {
                    dbContext.PostStocks.Remove(p);
                });
            dbContext.SaveChanges();            
        }
    }
}