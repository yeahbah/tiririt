using Tiririt.App.Service;
using Tiririt.Core.Collection;
using Tiririt.Data.Service;
using Tiririt.Domain.Models;
using Tiririt.Core.Extensions;
using Tiririt.Data.Internal;
using System.Threading.Tasks;
using Tiririt.Core.Enums;

namespace Tiririt.App.Internal.Service
{
    public class TiriritPostService : ITiriritPostService
    {
        private readonly TiriritDbContext dbContext;
        private readonly ITiriritPostRepository postRepository;
        private readonly IHashTagRepository hashTagRepository;
        private readonly IStockRepository stockRepository;

        public TiriritPostService(
            TiriritDbContext dbContext,            
            ITiriritPostRepository postRepository,
            IHashTagRepository hashTagRepository,
            IStockRepository stockRepository)
        {
            this.dbContext = dbContext;
            this.postRepository = postRepository;
            this.hashTagRepository = hashTagRepository;
            this.stockRepository = stockRepository;
        }

        public async Task DeletePost(int postId)
        {
            //TODO validate if user can delete

            using var transaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                await hashTagRepository.RemoveTagsFromPost(postId);
                await stockRepository.RemoveStockLinksFromPost(postId);                            
                
                await postRepository.DeletePost(postId);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<PagingResultEnvelope<PostModel>> GetPostsByUserId(int userId, PagingParam pagingParam)
        {
            return await postRepository.GetPostsByUserId(userId, pagingParam);
        }

        public async Task<PagingResultEnvelope<PostModel>> GetResponses(int postId, PagingParam pagingParam)
        {
            return await postRepository.GetResponses(postId, pagingParam);
        }   

        public async Task<PostModel> AddOrModifyPost(string postText, BullBearLevel bullBearLevel, int? postId = null, int? responseToPostId = null)
        {
            var tags = postText.ParseTags("#");
            var stocks = postText.ParseTags("$");

            using var transaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                if (postId == null) 
                {
                    postId = await postRepository.NewPost(postText, bullBearLevel, responseToPostId);
                }
                else
                {
                    await hashTagRepository.RemoveTagsFromPost(postId.Value, true);
                    await stockRepository.RemoveStockLinksFromPost(postId.Value, true);
                    await postRepository.ModifyPost(postId.Value, postText);
                }
                await hashTagRepository.AddTagsToPost(postId.Value, tags);
                await stockRepository.LinkPostToStocks(postId.Value, stocks);
                await transaction.CommitAsync();
                return await postRepository.GetPost(postId.Value);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<PostModel> LikeOrDislikePost(int postId, bool like)
        {
            return await postRepository.LikeOrDislikePost(postId, like);
        }
    }
}