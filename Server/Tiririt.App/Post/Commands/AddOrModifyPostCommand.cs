using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiririt.App.Models;
using Tiririt.App.Models.Mappings;
using Tiririt.Core.Enums;
using Tiririt.Core.Extensions;
using Tiririt.Core.Identity;
using Tiririt.Data.Internal;
using Tiririt.Data.Service;

namespace Tiririt.App.Post.Commands
{
    public record AddOrModifyPostCommand(
        string PostText, 
        BullBearLevel BullBearLevel, 
        int? PostId = null, 
        int? ResponseToPostId = null) : IRequest<PostViewModel>;

    public class NewPostCommandHandler : IRequestHandler<AddOrModifyPostCommand, PostViewModel>
    {
        private readonly TiriritDbContext dbContext;
        private readonly ITiriritPostRepository postRepository;
        private readonly IHashTagRepository hashTagRepository;
        private readonly IMentionRepository mentionRepository;
        private readonly IStockRepository stockRepository;
        private readonly ICurrentPrincipal currentPrincipal;

        public NewPostCommandHandler(TiriritDbContext dbContext,
            ITiriritPostRepository postRepository,
            IHashTagRepository hashTagRepository,
            IMentionRepository mentionRepository,
            IStockRepository stockRepository,
            ICurrentPrincipal currentPrincipal)
        {
            this.dbContext = dbContext;
            this.postRepository = postRepository;
            this.hashTagRepository = hashTagRepository;
            this.mentionRepository = mentionRepository;
            this.stockRepository = stockRepository;
            this.currentPrincipal = currentPrincipal;
        }

        public async Task<PostViewModel> Handle(AddOrModifyPostCommand request, CancellationToken cancellationToken)
        {
            var postText = request.PostText;
            var postId = request.PostId;
            var responseToPostId = request.ResponseToPostId;
            var bullBearLevel = request.BullBearLevel;

            var tags = postText.ParseTags("#");
            var stocks = postText.ParseTags("$");
            var mentions = postText.ParseTags("@");

            using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var tasks = new List<Task>();
                if (postId == null)
                {
                    postId = await postRepository.NewPost(postText, bullBearLevel, responseToPostId);
                }
                else
                {
                    // refactor to separate commands
                    await hashTagRepository.RemoveTagsFromPost(postId.Value, true);
                    await stockRepository.RemoveStockLinksFromPost(postId.Value, true);
                    await mentionRepository.RemoveMentions(postId.Value, true);
                    await postRepository.ModifyPost(postId.Value, postText);
                }
                await hashTagRepository.AddTagsToPost(postId.Value, tags);
                await stockRepository.LinkPostToStocks(postId.Value, stocks);
                await mentionRepository.AddPostMention(postId.Value, mentions);
                Task.WaitAll(tasks.ToArray(), cancellationToken);

                await transaction.CommitAsync(cancellationToken);

                var result = await postRepository.GetPost(postId.Value, cancellationToken);
                return result.ToViewModel(this.currentPrincipal);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
