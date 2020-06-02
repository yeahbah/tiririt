using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tiririt.Data.Internal;
using Tiririt.Domain.Models;
using Tiririt.Data.Internal.Mappings;
using Tiririt.Data.Entities;
using System;

namespace Tiririt.Data.Service
{
    internal class WatchListRepository : IWatchListRepository
    {
        private readonly TiriritDbContext dbContext;

        public WatchListRepository(TiriritDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<WatchListModel> AddStock(int watchlistId, string stockSymbol)
        {
            var stock = await dbContext.Stocks                
                .SingleOrDefaultAsync(s => s.SYMBOL == stockSymbol);
            if (stock == null) throw new Exception($"Unable to find {stockSymbol}");
            
            var watchList = dbContext.WatchListStocks.Add(new WATCH_LIST_STOCK {
                WATCH_LIST_ID = watchlistId,
                STOCK_ID = stock.STOCK_ID
            });
            await dbContext.SaveChangesAsync();
            return await GetWatchList(watchlistId);        
        }

        public async Task DeleteWatchList(int id)
        {
            var watchList = await dbContext.WatchLists
                .SingleOrDefaultAsync(w => w.WATCH_LIST_ID == id);
            if (watchList != null) 
            {
                watchList.DELETED_IND = 1;
                await dbContext.SaveChangesAsync();
            }
        }        

        public IQueryable<WatchListModel> GetAll()
        {
            return dbContext.WatchLists
                .AsNoTracking()                
                .Where(w => w.DELETED_IND == 0)
                .Select(data => new WatchListModel {
                    UserId = data.TIRIRIT_USER_ID,
                    WatchListId = data.WATCH_LIST_ID,
                    WatchListName = data.WATCH_LIST_NAME,
                    Stocks = data.Ref_Stocks.Select(stock => new StockModel
                    {
                        Name = stock.Ref_Stock.NAME,
                        StockQuotes = stock.Ref_Stock.Ref_StockQuotes
                            .Select(q => q.ToDomainModel()),
                        SectorId = stock.Ref_Stock.SECTOR_ID,
                        StockId = stock.Ref_Stock.STOCK_ID,
                        Symbol = stock.Ref_Stock.SYMBOL
                    })
                });
        }

        public async Task<IEnumerable<WatchListModel>> GetWatchList()
        {
            // TODO use current principal
            var currentPrincipal = 1;
            var query = GetAll()
                .Where(w => w.UserId == currentPrincipal);
            
            return await query.ToListAsync();
        }

        public async Task<WatchListModel> GetWatchList(int watchListId)
        {
            var result = await GetAll()
                .Where(w => w.WatchListId == watchListId)                        
                .SingleOrDefaultAsync();
            
            return result;
        }

        public async Task<WatchListModel> NewWatchList(WatchListModel watchListModel)
        {
            var watchList = new WATCH_LIST 
            {
                WATCH_LIST_NAME = watchListModel.WatchListName,
                TIRIRIT_USER_ID = watchListModel.UserId
            };
            dbContext.WatchLists.Add(watchList);
            
            watchListModel.Stocks.ToList()
                .ForEach(stock => {                    
                    var stocks = new WATCH_LIST_STOCK
                    {
                        Ref_WatchList = watchList,
                        STOCK_ID = stock.StockId                    
                    };
                    dbContext.WatchListStocks.Add(stocks);
                });
            
            await dbContext.SaveChangesAsync();
            return await GetWatchList(watchList.WATCH_LIST_ID);
        }

        public async Task<WatchListModel> RenameWatchList(int watchListId, string newName)
        {
            var watchList = await dbContext.WatchLists
                .SingleOrDefaultAsync(w => w.WATCH_LIST_ID == watchListId);
            if (watchList != null)
            {
                watchList.WATCH_LIST_NAME = newName;
                await dbContext.SaveChangesAsync();
                return await GetWatchList(watchList.WATCH_LIST_ID);
            }
            return null;
        }
    }
}