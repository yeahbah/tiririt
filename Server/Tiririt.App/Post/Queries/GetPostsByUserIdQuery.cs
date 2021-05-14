using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiririt.App.Models;
using Tiririt.App.Models.Mappings;
using Tiririt.Core.Collection;
using Tiririt.Core.Identity;
using Tiririt.Data.Service;

namespace Tiririt.App.Post.Queries
{
    public record GetPostsByUserIdQuery : BasePagingResultRequest, IRequest<PagingResultEnvelope<PostViewModel>>
    {
        public int UserId { get; set; }
    }

    public class GetPostsQueryHandler : IRequestHandler<GetPostsByUserIdQuery, PagingResultEnvelope<PostViewModel>>
    {
        private readonly ITiriritPostRepository tiriritPostRepository;
        private readonly ICurrentPrincipal currentPrincipal;

        public GetPostsQueryHandler(ITiriritPostRepository tiriritPostRepository, ICurrentPrincipal currentPrincipal)
        {
            this.tiriritPostRepository = tiriritPostRepository;
            this.currentPrincipal = currentPrincipal;
        }

        public async Task<PagingResultEnvelope<PostViewModel>> Handle(GetPostsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var pagedResult = await this.tiriritPostRepository.GetPostsByUserId(request.UserId, request.PagingParam, cancellationToken);
            var data = pagedResult.Data.Select(post => post.ToViewModel(this.currentPrincipal));
            return new PagingResultEnvelope<PostViewModel>(data, data.Count(), request.PagingParam);
        }
    }
}
