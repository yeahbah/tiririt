using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiririt.App.Models;
using Tiririt.App.Models.Mappings;
using Tiririt.Core.Identity;
using Tiririt.Data.Service;

namespace Tiririt.App.Stock.Queries
{
    public record GetStockQuery(string StockSymbol) : IRequest<StockViewModel>;

    public class GetStockQueryHandler : IRequestHandler<GetStockQuery, StockViewModel>
    {
        private readonly IStockRepository stockRepository;
        private readonly IWatchListRepository watchListRepository;
        private readonly ICurrentPrincipal currentPrincipal;

        public GetStockQueryHandler(
            IStockRepository stockRepository,
            IWatchListRepository watchListRepository,
            ICurrentPrincipal currentPrincipal)
        {
            this.stockRepository = stockRepository;
            this.watchListRepository = watchListRepository;
            this.currentPrincipal = currentPrincipal;
        }

        public async Task<StockViewModel> Handle(GetStockQuery request, CancellationToken cancellationToken)
        {
            var stock = await this.stockRepository.GetStock(request.StockSymbol, cancellationToken);
            var result = stock.ToViewModel();
            var userId = this.currentPrincipal.GetUserId();
            if (userId != null)
            {
                result.IsWatchedByUser = await this.watchListRepository.IsWatchedByUser(request.StockSymbol, userId.Value);
            }
            return result;
        }
    }
}
