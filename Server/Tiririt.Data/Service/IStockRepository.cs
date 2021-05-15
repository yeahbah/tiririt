using System.Threading;
using System.Threading.Tasks;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Service
{
    public interface IStockRepository
    {
        Task<StockModel> GetStock(string stockSymbol, CancellationToken cancellationToken = default);
        Task<StockModel> AddStock(StockModel stockModel, CancellationToken cancellationToken = default);

        /// <summary>
        /// Link stocks to a post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="symbol"></param>
        Task LinkPostToStocks(int postId, string[] symbol);

        /// <summary>
        /// Unlink a stock from a post
        /// </summary>
        /// <param name="postId"></param>
        Task RemoveStockLinksFromPost(int postId, bool permanent = false);
    }
}