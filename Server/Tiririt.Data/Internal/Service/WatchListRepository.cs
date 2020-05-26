using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tiririt.Data.Internal;
using Tiririt.Domain.Models;
using Tiririt.Data.Internal.Mappings;

namespace Tiririt.Data.Service
{
    internal class WatchListRepository : IWatchListRepository
    {
        private readonly TiriritDbContext dbContext;

        public WatchListRepository(TiriritDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}