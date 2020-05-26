using System.Collections.Generic;
using Tiririt.Domain.Models;

namespace Tiririt.App.Service
{
    public interface IWatchListService
    {
        IEnumerable<WatchListModel> GetWatchList();
    }
}