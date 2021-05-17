using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiririt.App.Models;
using Tiririt.App.Models.Mappings;
using Tiririt.Data.Service;

namespace Tiririt.App.WatchList.Commands
{
    public record AddStocksToWatchListCommand(int Id, IEnumerable<string> StockSymbols) : IRequest<WatchListViewModel>;

    public class AddStocksToWatchListCommandHandler : IRequestHandler<AddStocksToWatchListCommand, WatchListViewModel>
    {
        private readonly IWatchListRepository watchListRepository;

        public AddStocksToWatchListCommandHandler(IWatchListRepository watchListRepository)
        {
            this.watchListRepository = watchListRepository;
        }
        public async Task<WatchListViewModel> Handle(AddStocksToWatchListCommand request, CancellationToken cancellationToken)
        {
            var result = await this.watchListRepository.AddStocks(request.Id, request.StockSymbols.Distinct(), cancellationToken);
            return result.ToViewModel();
        }
    }
}
