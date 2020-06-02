using System.Threading.Tasks;
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

        public async Task<StockModel> AddStock(StockModel stockModel)
        {
            return await this.stockRepository.AddStock(stockModel);
        }        

        public async Task<StockModel> GetStock(string stockSymbol)
        {
            return await stockRepository.GetStock(stockSymbol);
        }
    }
}