using System.Threading.Tasks;
using Tiririt.Domain.Models;

namespace Tiririt.App.Service
{
    public interface IStockService
    {
        Task<StockModel> GetStock(string stockSymbol);
        Task<StockModel> AddStock(StockModel stockModel);
    }
}