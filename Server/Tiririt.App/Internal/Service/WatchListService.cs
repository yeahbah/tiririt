using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tiririt.App.Service;
using Tiririt.Data.Service;
using Tiririt.Domain.Models;

namespace Tiririt.App.Internal.Service
{
    public class WatchListService : IWatchListService
    {
        private readonly IWatchListRepository watchListRepository;

        public WatchListService(IWatchListRepository watchListRepository)
        {
            this.watchListRepository = watchListRepository;
        }

        public async Task<WatchListModel> AddStock(int id, string stockSymbol)
        {
            return await watchListRepository.AddStock(id, stockSymbol);
        }

        public async Task DeleteWatchList(int id)
        {
            await watchListRepository.DeleteWatchList(id);
        }

        public async Task<IEnumerable<WatchListModel>> GetWatchList()
        {            
            return await watchListRepository.GetWatchList();            
        }

        public async Task<WatchListModel> NewWatchList(WatchListModel watchListModel)
        {
            return await watchListRepository.NewWatchList(watchListModel);
        }

        public async Task<WatchListModel> RenameWatchList(int id, string newName)
        {
            return await watchListRepository.RenameWatchList(id, newName);
        }
    }
}