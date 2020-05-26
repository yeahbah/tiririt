using System.Collections.Generic;
using Tiririt.Domain.Models;

namespace Tiririt.App.Service
{
    public interface IWatchListService
    {
        IEnumerable<WatchListModel> GetWatchList();
        WatchListModel AddStock(int id, string stockSymbol);
        WatchListModel RenameWatchList(int id, string newName);
        void DeleteWatchList(int id);
        WatchListModel NewWatchList(WatchListModel watchListModel);
    }
}