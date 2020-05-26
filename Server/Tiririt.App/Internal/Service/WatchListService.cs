using System.Collections.Generic;
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

        public WatchListModel AddStock(int id, string stockSymbol)
        {
            return watchListRepository.AddStock(id, stockSymbol);
        }

        public void DeleteWatchList(int id)
        {
            watchListRepository.DeleteWatchList(id);
        }

        public IEnumerable<WatchListModel> GetWatchList()
        {            
            return watchListRepository.GetWatchList().Result;            
        }

        public WatchListModel NewWatchList(WatchListModel watchListModel)
        {
            return watchListRepository.NewWatchList(watchListModel);
        }

        public WatchListModel RenameWatchList(int id, string newName)
        {
            return watchListRepository.RenameWatchList(id, newName);
        }
    }
}