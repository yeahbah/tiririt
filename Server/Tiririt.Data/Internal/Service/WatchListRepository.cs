using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tiririt.Core.Identity;
using Tiririt.Data.Entities;
using Tiririt.Data.Internal;
using Tiririt.Data.Internal.Mappings;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Service
{
    internal class WatchListRepository : IWatchListRepository
    {
        private readonly TiriritDbContext dbContext;
        private readonly ICurrentPrincipal currentPrincipal;

        public WatchListRepository(TiriritDbContext dbContext, ICurrentPrincipal currentPrincipal)
        {
            this.dbContext = dbContext;
            this.currentPrincipal = currentPrincipal;
        }

        public async Task<WatchListModel> AddStocks(int watchlistId, IEnumerable<string> stockSymbols)
        {
            // must exist in Stock table
            // must not exist in user watch list
            var stocks = stockSymbols.Select(s => s.ToUpper());
            var userId = this.currentPrincipal.GetUserId();
            var stocksToAdd = await dbContext.Stocks                
                .Where(s => stocks.ToArray().Contains(s.SYMBOL.ToUpper())
                    && !s.Ref_StocksInWatchLists.Any(w => w.Ref_WatchList.TIRIRIT_USER_ID == userId && w.STOCK_ID == s.STOCK_ID))                
                .ToListAsync();
                           
            stocksToAdd.ForEach(s =>
            {
                dbContext.WatchListStocks.Add(new WATCH_LIST_STOCK
                {
                    WATCH_LIST_ID = watchlistId,
                    STOCK_ID = s.STOCK_ID
                });
            });
            await dbContext.SaveChangesAsync();
            return await GetWatchList(watchlistId);        
        }

        public async Task<WatchListModel> DeleteStocks(int id, string symbol)
        {
            var userId = this.currentPrincipal.GetUserId();

            var stocks = this.dbContext.WatchListStocks
                .Where(w => w.Ref_WatchList.TIRIRIT_USER_ID == userId && w.Ref_Stock.SYMBOL == symbol.ToUpper());
            dbContext.WatchListStocks.RemoveRange(stocks);
            await dbContext.SaveChangesAsync();

            return await GetWatchList(id);
        }

        public async Task DeleteWatchList(int id)
        {
            var userId = this.currentPrincipal.GetUserId();
            var watchList = await dbContext.WatchLists
                .SingleOrDefaultAsync(w => w.WATCH_LIST_ID == id && w.TIRIRIT_USER_ID == userId);
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
            var userId = this.currentPrincipal.GetUserId();
            var query = GetAll()
                .Where(w => w.UserId == userId);
            
            return await query.ToListAsync();
        }

        public async Task<WatchListModel> GetWatchList(int watchListId)
        {
            var result = await GetAll()
                .Where(w => w.WatchListId == watchListId)                        
                .SingleOrDefaultAsync();
            
            return result;
        }

        public async Task<WatchListModel> NewWatchList(NewWatchListModel watchListModel)
        {
            var userId = this.currentPrincipal.GetUserId();
            var watchList = new WATCH_LIST
            {
                WATCH_LIST_NAME = watchListModel.Name,
                TIRIRIT_USER_ID = userId
            };
            dbContext.WatchLists.Add(watchList);

            if (watchListModel.Stocks.Any())
            {
                var stocks = await dbContext.Stocks
                    .Where(stock => watchListModel.Stocks.Contains(stock.SYMBOL))
                    .ToListAsync();

                stocks.ForEach(stock =>
                {
                    var stocks = new WATCH_LIST_STOCK
                    {
                        Ref_WatchList = watchList,
                        STOCK_ID = stock.STOCK_ID
                    };
                    dbContext.WatchListStocks.Add(stocks);
                });
            }
            
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