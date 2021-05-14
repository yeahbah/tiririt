using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiririt.App.Models;
using Tiririt.App.Models.Mappings;
using Tiririt.Core.Identity;
using Tiririt.Data.Service;

namespace Tiririt.App.Post.Commands
{
    public record LikeDislikeCommand(int PostId, int Like) : IRequest<PostViewModel>;

    public class LikeDislikeCommandHandler : IRequestHandler<LikeDislikeCommand, PostViewModel>
    {
        private readonly ITiriritPostRepository postRepository;
        private readonly ICurrentPrincipal currentPrincipal;

        public LikeDislikeCommandHandler(ITiriritPostRepository postRepository, ICurrentPrincipal currentPrincipal)
        {
            this.postRepository = postRepository;
            this.currentPrincipal = currentPrincipal;
        }

        public async Task<PostViewModel> Handle(LikeDislikeCommand request, CancellationToken cancellationToken)
        {
            var result = await this.postRepository.LikeOrDislikePost(request.PostId, request.Like == 1, cancellationToken);
            return result.ToViewModel(this.currentPrincipal);
        }
    }
}
