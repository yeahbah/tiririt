using System.Collections.Generic;
using System.Threading.Tasks;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Service
{
    public interface IWatchListRepository
    {
        // get default watchlist
        Task<IEnumerable<WatchListModel>> GetWatchList();
        WatchListModel GetWatchList(int watchListId);
        WatchListModel AddStock(int id, string stockSymbol);
        void DeleteWatchList(int id);
        WatchListModel NewWatchList(WatchListModel watchListModel);
        WatchListModel RenameWatchList(int id, string newName);
    }
}