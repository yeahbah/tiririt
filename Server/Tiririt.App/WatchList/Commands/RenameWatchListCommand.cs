using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiririt.App.Models;
using Tiririt.App.Models.Mappings;
using Tiririt.Data.Service;

namespace Tiririt.App.WatchList.Commands
{
    public record RenameWatchListCommand(int Id, string NewWatchListName) : IRequest<WatchListViewModel>;

    public class RenameWatchListCommandHandler : IRequestHandler<RenameWatchListCommand, WatchListViewModel>
    {
        private readonly IWatchListRepository watchListRepository;

        public RenameWatchListCommandHandler(IWatchListRepository watchListRepository)
        {
            this.watchListRepository = watchListRepository;
        }

        public async Task<WatchListViewModel> Handle(RenameWatchListCommand request, CancellationToken cancellationToken)
        {
            var result = await this.watchListRepository.RenameWatchList(request.Id, request.NewWatchListName, cancellationToken);
            return result.ToViewModel();
        }
    }
}
