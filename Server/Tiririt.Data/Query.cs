using HotChocolate;
using HotChocolate.Types;
using System.Linq;
using Tiririt.Data.Entities;
using Tiririt.Data.Internal;

namespace Tiririt.Data
{
    public class Query
    {        
        //[UseSelection]
        public IQueryable<STOCK> GetStocks([Service] TiriritDbContext context)
            => context.Stocks;

        public IQueryable<HASH_TAG> GetHashTags([Service] TiriritDbContext context)
            => context.HashTags;

        public IQueryable<TIRIRIT_POST> GetPosts([Service] TiriritDbContext context)
            => context.TiriritPosts;

        public IQueryable<WATCH_LIST> GetWatchLists([Service] TiriritDbContext context)
            => context.WatchLists;

        public IQueryable<STOCK_QUOTE> GetStockQuotes([Service] TiriritDbContext context)
            => context.StockQuotes;
    }
}
