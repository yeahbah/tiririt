using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiririt.App.Models;
using Tiririt.App.Models.Mappings;
using Tiririt.Core.Identity;
using Tiririt.Data.Service;

namespace Tiririt.App.Post.Queries
{
    public record GetPostQuery : IRequest<PostViewModel>
    {
        public int PostId { get; set; }
    }

    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, PostViewModel>
    {
        private readonly ITiriritPostRepository postRepository;
        private readonly ICurrentPrincipal currentPrincipal;

        public GetPostQueryHandler(ITiriritPostRepository postRepository, ICurrentPrincipal currentPrincipal)
        {
            this.postRepository = postRepository;
            this.currentPrincipal = currentPrincipal;
        }

        public async Task<PostViewModel> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var result = await this.postRepository.GetPost(request.PostId, cancellationToken);
            return result.ToViewModel(this.currentPrincipal);
        }
    }
}
