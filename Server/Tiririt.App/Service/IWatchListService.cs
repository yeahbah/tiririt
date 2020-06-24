using System.Collections.Generic;
using System.Threading.Tasks;
using Tiririt.Domain.Models;

namespace Tiririt.App.Service
{
    public interface IWatchListService
    {
        Task<IEnumerable<WatchListModel>> GetWatchList();
        Task<WatchListModel> AddStocks(int id, IEnumerable<string> stocks);
        Task<WatchListModel> RenameWatchList(int id, string newName);
        Task DeleteWatchList(int id);
        Task<WatchListModel> NewWatchList(NewWatchListModel watchListModel);
        Task<WatchListModel> DeleteStocks(int id, string symbol);
        Task<bool> IsWatchedByUser(string symbol, int userId);
    }
}