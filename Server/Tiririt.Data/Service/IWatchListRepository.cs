using System.Collections.Generic;
using System.Threading.Tasks;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Service
{
    public interface IWatchListRepository
    {
        Task<IEnumerable<WatchListModel>> GetWatchList();        
    }
}