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
    public record GetCommentsQuery : BasePagingResultRequest, IRequest<PagingResultEnvelope<PostViewModel>>
    {
        public int PostId { get; set; }
    }

    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, PagingResultEnvelope<PostViewModel>>
    {
        private readonly ITiriritPostRepository postRepository;
        private readonly ICurrentPrincipal currentPrincipal;

        public GetCommentsQueryHandler(ITiriritPostRepository postRepository, ICurrentPrincipal currentPrincipal)
        {
            this.postRepository = postRepository;
            this.currentPrincipal = currentPrincipal;
        }

        public async Task<PagingResultEnvelope<PostViewModel>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var pagedResult = await this.postRepository.GetComments(request.PostId, request.PagingParam, cancellationToken);
            var data = pagedResult.Data.Select(post => post.ToViewModel(this.currentPrincipal));
            return new PagingResultEnvelope<PostViewModel>(data, data.Count(), request.PagingParam);
        }
    }
}
