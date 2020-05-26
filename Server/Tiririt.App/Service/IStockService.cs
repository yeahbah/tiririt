using Tiririt.Domain.Models;

namespace Tiririt.App.Service
{
    public interface IStockService
    {
        StockModel GetStock(string stockSymbol);
        StockModel AddStock(StockModel stockModel);
    }
}