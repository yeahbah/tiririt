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

        public WatchListModel AddStock(int watchlistId, string stockSymbol)
        {
            var stock = dbContext.Stocks                
                .SingleOrDefault(s => s.SYMBOL == stockSymbol);
            if (stock == null) throw new Exception($"Unable to find {stockSymbol}");
            
            var watchList = dbContext.WatchListStocks.Add(new WATCH_LIST_STOCK {
                WATCH_LIST_ID = watchlistId,
                STOCK_ID = stock.STOCK_ID
            });
            dbContext.SaveChanges();
            return GetWatchList(watchlistId);        
        }

        public void DeleteWatchList(int id)
        {
            var watchList = dbContext.WatchLists
                .SingleOrDefault(w => w.WATCH_LIST_ID == id);
            if (watchList != null) 
            {
                dbContext.Remove(watchList);
            }
        }        

        public async Task<IEnumerable<WatchListModel>> GetWatchList()
        {
            // TODO use current principal
            var currentPrincipal = 1;
            var query = dbContext.WatchLists
                .AsNoTracking()
                .Where(w => w.TIRIRIT_USER_ID == currentPrincipal)
                //.SelectMany(w => w.Ref_Stocks, (watchList, stock) => new { WatchList = watchList, Stocks = stock} )
                .Select(data => new WatchListModel {
                    UserId = data.TIRIRIT_USER_ID,
                    WatchListId = data.WATCH_LIST_ID,
                    WatchListName = data.WATCH_LIST_NAME,
                    Stocks = data.Ref_Stocks.Select(stock => stock.Ref_Stock.ToDomainModel())
                });
            
            return await query.ToListAsync();
        }

        public WatchListModel GetWatchList(int watchListId)
        {
            var result = dbContext.WatchLists
                .Where(w => w.WATCH_LIST_ID == watchListId)        
                .Select(data => new WatchListModel {
                    Stocks = data.Ref_Stocks.Select(s => s.Ref_Stock.ToDomainModel()),
                    WatchListId = data.WATCH_LIST_ID,
                    UserId = data.TIRIRIT_USER_ID,
                    WatchListName = data.WATCH_LIST_NAME                    
                })
                .SingleOrDefault();
            
            return result;
        }

        public WatchListModel NewWatchList(WatchListModel watchListModel)
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
            
            dbContext.SaveChanges();
            return GetWatchList(watchList.WATCH_LIST_ID);
        }

        public WatchListModel RenameWatchList(int watchListId, string newName)
        {
            var watchList = dbContext.WatchLists
                .SingleOrDefault(w => w.WATCH_LIST_ID == watchListId);
            if (watchList != null)
            {
                watchList.WATCH_LIST_NAME = newName;
                dbContext.SaveChanges();
                return GetWatchList(watchList.WATCH_LIST_ID);
            }
            return null;
        }
    }
}