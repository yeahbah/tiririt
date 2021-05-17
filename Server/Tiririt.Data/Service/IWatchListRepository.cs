using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tiririt.Core.Collection;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Service
{
    public interface IWatchListRepository
    {
        // get default watchlist
        Task<IEnumerable<WatchListModel>> GetWatchList(CancellationToken cancellationToken = default);
        Task<WatchListModel> GetWatchList(int watchListId, CancellationToken cancellationToken = default);
        Task<WatchListModel> AddStocks(int id, IEnumerable<string> stocks, CancellationToken cancellationToken = default);
        Task DeleteWatchList(int id, CancellationToken cancellationToken = default);
        Task<WatchListModel> NewWatchList(NewWatchListModel watchListModel, CancellationToken cancellationToken = default);
        Task<WatchListModel> RenameWatchList(int id, string newName, CancellationToken cancellationToken = default);
        Task<WatchListModel> DeleteStocks(int id, string symbol, CancellationToken cancellationToken = default);
        Task<bool> IsWatchedByUser(string symbol, int userId, CancellationToken cancellationToken = default);
        Task<PagingResultEnvelope<StockModel>> GetStocksFromWatchlist(int watchListId, PagingParam pagingParam, CancellationToken cancellationToken = default);
    }
}