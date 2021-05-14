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
    public record SearchFeedQuery : BasePagingResultRequest, IRequest<PagingResultEnvelope<PostViewModel>>
    {
        public string SearchText { get; init; }
    }

    public class SearchFeedQueryHandler : IRequestHandler<SearchFeedQuery, PagingResultEnvelope<PostViewModel>>
    {
        private readonly IFeedRepository feedRepository;
        private readonly ICurrentPrincipal currentPrincipal;

        public SearchFeedQueryHandler(IFeedRepository feedRepository, ICurrentPrincipal currentPrincipal)
        {
            this.feedRepository = feedRepository;
            this.currentPrincipal = currentPrincipal;
        }

        public async Task<PagingResultEnvelope<PostViewModel>> Handle(SearchFeedQuery request, CancellationToken cancellationToken)
        {
            var pagedResult = await this.feedRepository.Search(request.SearchText, request.PagingParam, cancellationToken);
            var data = pagedResult.Data.Select(post => post.ToViewModel(this.currentPrincipal));
            return new PagingResultEnvelope<PostViewModel>(data, data.Count(), request.PagingParam);
        }
    }
}
