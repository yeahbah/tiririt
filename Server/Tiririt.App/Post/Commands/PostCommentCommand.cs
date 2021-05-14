using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiririt.App.Models;
using Tiririt.Core.Enums;

namespace Tiririt.App.Post.Commands
{
    public record PostCommentCommand(int PostId, string CommentText) : IRequest<PostViewModel>;

    public class PostCommentCommandHandler : IRequestHandler<PostCommentCommand, PostViewModel>
    {
        private readonly IMediator mediator;

        public PostCommentCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<PostViewModel> Handle(PostCommentCommand request, CancellationToken cancellationToken)
        {
            var result = await this.mediator.Send(
                new AddOrModifyPostCommand(request.CommentText, BullBearLevel.Neutral, null, request.PostId),
                cancellationToken);
            return result;
        }
    }
}
