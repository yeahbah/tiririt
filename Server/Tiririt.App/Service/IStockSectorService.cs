using System.Threading.Tasks;
using Tiririt.Domain.Models;

namespace Tiririt.App.Service
{
    public interface IStockSectorService
    {
        Task<StockSectorModel> AddSector(StockSectorModel sector);
        Task<StockSectorModel> GetSector(string name);
    }
}