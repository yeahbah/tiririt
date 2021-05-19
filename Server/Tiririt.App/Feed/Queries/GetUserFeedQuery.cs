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
    public record GetUserFeedQuery : BasePagingResultRequest, IRequest<PagingResultEnvelope<PostViewModel>>
    {
        
    }

    public class FeedQueryHandler : IRequestHandler<GetUserFeedQuery, PagingResultEnvelope<PostViewModel>>
    {
        private readonly IFeedRepository feedRepository;
        private readonly ICurrentPrincipal currentPrincipal;

        public FeedQueryHandler(IFeedRepository feedRepository, ICurrentPrincipal currentPrincipal)
        {
            this.feedRepository = feedRepository;
            this.currentPrincipal = currentPrincipal;
        }

        public async Task<PagingResultEnvelope<PostViewModel>> Handle(GetUserFeedQuery request, CancellationToken cancellationToken)
        {
            var pagedResult = await this.feedRepository.GetUserFeed(request.PagingParam, cancellationToken);
            var data = pagedResult.Data.Select(post => post.ToViewModel(this.currentPrincipal));
            
            return new PagingResultEnvelope<PostViewModel>(data, pagedResult.TotalCount, request.PagingParam);
        }
    }
}
