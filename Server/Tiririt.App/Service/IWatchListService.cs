using System.Collections.Generic;
using System.Threading.Tasks;
using Tiririt.Domain.Models;

namespace Tiririt.App.Service
{
    public interface IWatchListService
    {
        Task<IEnumerable<WatchListModel>> GetWatchList();
        Task<WatchListModel> AddStock(int id, string stockSymbol);
        Task<WatchListModel> RenameWatchList(int id, string newName);
        Task DeleteWatchList(int id);
        Task<WatchListModel> NewWatchList(WatchListModel watchListModel);
    }
}