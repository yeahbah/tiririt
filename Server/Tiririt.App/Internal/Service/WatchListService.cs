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

        public IEnumerable<WatchListModel> GetWatchList()
        {            
            return watchListRepository.GetWatchList().Result;            
        }
    }
}