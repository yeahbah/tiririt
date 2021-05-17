using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiririt.Data.Service;

namespace Tiririt.App.WatchList.Commands
{
    public record DeleteWatchListCommand(int Id) : IRequest<Unit>;

    public class DeleteWatchListCommandHandler : IRequestHandler<DeleteWatchListCommand, Unit>
    {
        private readonly IWatchListRepository watchListRepository;

        public DeleteWatchListCommandHandler(IWatchListRepository watchListRepository)
        {
            this.watchListRepository = watchListRepository;
        }

        public async Task<Unit> Handle(DeleteWatchListCommand request, CancellationToken cancellationToken)
        {
            await this.watchListRepository.DeleteWatchList(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
