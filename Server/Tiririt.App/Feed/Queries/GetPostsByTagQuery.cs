using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiririt.App.Models;
using Tiririt.App.Models.Mappings;
using Tiririt.Core.Collection;
using Tiririt.Core.CQRS;
using Tiririt.Core.Identity;
using Tiririt.Data.Service;

namespace Tiririt.App.Feed.Queries
{
    public record GetPostsByTagQuery : BasePagingResultRequest, IRequest<PagingResultEnvelope<PostViewModel>>
    {
        public string Tag { get; init; }
    }

    public class GetPostsByTagQueryHandler : IRequestHandler<GetPostsByTagQuery, PagingResultEnvelope<PostViewModel>>
    {
        private readonly IFeedRepository feedRepository;
        private readonly ICurrentPrincipal currentPrincipal;

        public GetPostsByTagQueryHandler(IFeedRepository feedRepository, ICurrentPrincipal currentPrincipal)
        {
            this.feedRepository = feedRepository;
            this.currentPrincipal = currentPrincipal;
        }

        public async Task<PagingResultEnvelope<PostViewModel>> Handle(GetPostsByTagQuery request, CancellationToken cancellationToken)
        {
            var pagingResult = await this.feedRepository.GetPostsByTag(request.Tag, request.PagingParam, cancellationToken);
            var data = pagingResult.Data.Select(post => post.ToViewModel(this.currentPrincipal));
            return new PagingResultEnvelope<PostViewModel>(data, data.Count(), request.PagingParam);
        }
    }
}
