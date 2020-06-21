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

        public async Task<WatchListModel> AddStocks(int id, IEnumerable<string> stocks)
        {
            return await watchListRepository.AddStocks(id, stocks);
        }

        public async Task<WatchListModel> DeleteStocks(int id, string symbol)
        {
            return await watchListRepository.DeleteStocks(id, symbol);
        }

        public async Task DeleteWatchList(int id)
        {
            await watchListRepository.DeleteWatchList(id);
        }

        public async Task<IEnumerable<WatchListModel>> GetWatchList()
        {            
            return await watchListRepository.GetWatchList();            
        }

        public async Task<WatchListModel> NewWatchList(NewWatchListModel watchListModel)
        {
            return await watchListRepository.NewWatchList(watchListModel);
        }

        public async Task<WatchListModel> RenameWatchList(int id, string newName)
        {
            return await watchListRepository.RenameWatchList(id, newName);
        }
    }
}