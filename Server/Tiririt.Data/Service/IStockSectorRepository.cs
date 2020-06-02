using System.Threading.Tasks;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Service
{
    public interface IStockSectorRepository 
    {
        Task<StockSectorModel> AddSector(StockSectorModel sectorModel);
        Task<StockSectorModel> GetSector(string name);
    }
}