using System;
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
    public record NewWatchListCommand(string Name, IEnumerable<string> StockSymbols) : IRequest<WatchListViewModel>;

    public class NewWatchListCommandHandler : IRequestHandler<NewWatchListCommand, WatchListViewModel>
    {
        private readonly IWatchListRepository watchListRepository;

        public NewWatchListCommandHandler(IWatchListRepository watchListRepository)
        {
            this.watchListRepository = watchListRepository;
        }

        public async Task<WatchListViewModel> Handle(NewWatchListCommand request, CancellationToken cancellationToken)
        {
            var result = await this.watchListRepository.NewWatchList(new Domain.Models.NewWatchListModel
            {
                Name = request.Name,
                Stocks = request.StockSymbols
                        .Distinct()
                        .Select(stock => stock.ToUpper())
            });
            return result.ToViewModel();
        }
    }
}
