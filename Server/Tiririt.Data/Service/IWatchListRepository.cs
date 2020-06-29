using System.Collections.Generic;
using System.Threading.Tasks;
using Tiririt.Core.Collection;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Service
{
    public interface IWatchListRepository
    {
        // get default watchlist
        Task<IEnumerable<WatchListModel>> GetWatchList();
        Task<WatchListModel> GetWatchList(int watchListId);
        Task<WatchListModel> AddStocks(int id, IEnumerable<string> stocks);
        Task DeleteWatchList(int id);
        Task<WatchListModel> NewWatchList(NewWatchListModel watchListModel);
        Task<WatchListModel> RenameWatchList(int id, string newName);
        Task<WatchListModel> DeleteStocks(int id, string symbol);
        Task<bool> IsWatchedByUser(string symbol, int userId);
        Task<PagingResultEnvelope<StockModel>> GetStocksFromWatchlist(int watchListId, PagingParam pagingParam);
    }
}