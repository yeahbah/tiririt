using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiririt.App.Models;
using Tiririt.App.Models.Mappings;
using Tiririt.Core.Collection;
using Tiririt.Core.CQRS;
using Tiririt.Data.Service;

namespace Tiririt.App.WatchList.Queries
{
    public record GetDefaultWatchListQuery : BasePagingResultRequest, IRequest<PagingResultEnvelope<StockViewModel>>;

    public class GetDefaultWatchListQueryHandler : IRequestHandler<GetDefaultWatchListQuery, PagingResultEnvelope<StockViewModel>>
    {
        private readonly IWatchListRepository watchListRepository;

        public GetDefaultWatchListQueryHandler(IWatchListRepository watchListRepository)
        {
            this.watchListRepository = watchListRepository;
        }

        public async Task<PagingResultEnvelope<StockViewModel>> Handle(GetDefaultWatchListQuery request, CancellationToken cancellationToken)
        {
            var pagedResult = await this.watchListRepository.GetStocksFromWatchlist(0, request.PagingParam, cancellationToken);
            var data = pagedResult.Data.Select(stock => stock.ToViewModel());
            return new PagingResultEnvelope<StockViewModel>(data, data.Count(), request.PagingParam);
        }
    }
}
