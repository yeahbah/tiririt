using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiririt.App.Models;
using Tiririt.App.Models.Mappings;
using Tiririt.Data.Service;

namespace Tiririt.App.WatchList.Commands
{
    public record DeleteStockFromWatchListCommand(int Id, string Symbol) : IRequest<WatchListViewModel>;

    public class DeleteStockFromWatchListCommandHandler : IRequestHandler<DeleteStockFromWatchListCommand, WatchListViewModel>
    {
        private readonly IWatchListRepository watchListRepository;

        public DeleteStockFromWatchListCommandHandler(IWatchListRepository watchListRepository)
        {
            this.watchListRepository = watchListRepository;
        }

        public async Task<WatchListViewModel> Handle(DeleteStockFromWatchListCommand request, CancellationToken cancellationToken)
        {
            var result = await this.watchListRepository.DeleteStocks(request.Id, request.Symbol, cancellationToken);
            return result.ToViewModel();            
        }
    }
}
