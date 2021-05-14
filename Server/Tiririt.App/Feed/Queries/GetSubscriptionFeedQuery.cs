using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiririt.App.Models;
using Tiririt.App.Models.Mappings;
using Tiririt.Core.Collection;
using Tiririt.Core.Identity;
using Tiririt.Data.Service;

namespace Tiririt.App.Feed.Queries
{
    public record GetSubscriptionFeedQuery : BasePagingResultRequest, IRequest<PagingResultEnvelope<PostViewModel>>
    {
        
    }

    public class GetSubscriptionFeedQuerHandler : IRequestHandler<GetSubscriptionFeedQuery, PagingResultEnvelope<PostViewModel>>
    {
        private readonly IFeedRepository repository;
        private readonly ICurrentPrincipal currentPrincipal;

        public GetSubscriptionFeedQuerHandler(IFeedRepository repository, ICurrentPrincipal currentPrincipal)
        {
            this.repository = repository;
            this.currentPrincipal = currentPrincipal;
        }

        public async Task<PagingResultEnvelope<PostViewModel>> Handle(GetSubscriptionFeedQuery request, CancellationToken cancellationToken)
        {
            var pagingResult = await this.repository.GetSubscriptionFeed(request.PagingParam, cancellationToken);
            var data = pagingResult.Data.Select(post => post.ToViewModel(this.currentPrincipal));

            return new PagingResultEnvelope<PostViewModel>(data, data.Count(), request.PagingParam);
        }
    }
}
