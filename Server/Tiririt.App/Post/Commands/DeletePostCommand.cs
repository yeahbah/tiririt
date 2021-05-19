using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiririt.Core.CQRS;
using Tiririt.Data.Internal;
using Tiririt.Data.Service;

namespace Tiririt.App.Post.Commands
{
    public record DeletePostCommand(int PostId) : IRequest<BaseResponse>;

    public class DeletPostCommandHandler : IRequestHandler<DeletePostCommand, BaseResponse>
    {
        private readonly TiriritDbContext dbContext;
        private readonly IHashTagRepository hashTagRepository;
        private readonly ITiriritPostRepository postRepository;
        private readonly IStockRepository stockRepository;

        public DeletPostCommandHandler(TiriritDbContext dbContext, IHashTagRepository hashTagRepository, ITiriritPostRepository postRepository, IStockRepository stockRepository)
        {
            this.dbContext = dbContext;
            this.hashTagRepository = hashTagRepository;
            this.postRepository = postRepository;
            this.stockRepository = stockRepository;
        }

        public async Task<BaseResponse> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var tasks = new List<Task>
                {
                    hashTagRepository.RemoveTagsFromPost(request.PostId),
                    stockRepository.RemoveStockLinksFromPost(request.PostId),
                    postRepository.DeletePost(request.PostId)
                };
                Task.WaitAll(tasks.ToArray(), cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                return new BaseResponse();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new BaseResponse
                {
                    ErrorMessage = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
            }
        }
    }
}
