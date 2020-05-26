using System.Threading.Tasks;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Service
{
    public interface IStockRepository
    {
        Task<StockModel> GetStock(string stockSymbol);
        StockModel AddStock(StockModel stockModel);
    }
}