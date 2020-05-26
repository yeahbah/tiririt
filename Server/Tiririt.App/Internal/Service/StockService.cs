using Tiririt.App.Service;
using Tiririt.Data.Service;
using Tiririt.Domain.Models;

namespace Tiririt.App.Internal.Service
{
    public class StockService : IStockService
    {
        private readonly IStockRepository stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            this.stockRepository = stockRepository;
        }

        public StockModel AddStock(StockModel stockModel)
        {
            return this.stockRepository.AddStock(stockModel);
        }        

        public StockModel GetStock(string stockSymbol)
        {
            return stockRepository.GetStock(stockSymbol).Result;
        }
    }
}