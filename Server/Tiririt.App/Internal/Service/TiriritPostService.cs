using Tiririt.App.Service;
using Tiririt.Core.Collection;
using Tiririt.Data.Service;
using Tiririt.Domain.Models;
using Tiririt.Core.Extensions;
using Tiririt.Data.Internal;

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

        public void DeletePost(int postId)
        {
            //TODO validate if user can delete

            using var transaction = dbContext.Database.BeginTransaction();
            try
            {
                hashTagRepository.RemoveTagsFromPost(postId);
                stockRepository.RemoveStockLinksFromPost(postId);            
                var responses = postRepository.GetResponsesNoPaging(postId);
                foreach(var response in responses) 
                {
                    postRepository.DeletePost(response.PostId);
                }
                postRepository.DeletePost(postId);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public PagingResultEnvelope<PostModel> GetPostsByUserId(int userId, PagingParam pagingParam)
        {
            var result = postRepository.GetPostsByUserId(userId, pagingParam);
            return result;
        }

        public PagingResultEnvelope<PostModel> GetResponses(int postId, PagingParam pagingParam)
        {
            var result = postRepository.GetResponses(postId, pagingParam);
            return result;
        }   

        public PostModel AddOrModifyPost(string postText, int? postId = null, int? responseToPostId = null)
        {
            var tags = postText.ParseTags("#");
            var stocks = postText.ParseTags("$");

            using var transaction = dbContext.Database.BeginTransaction();
            try
            {
                if (postId == null) 
                {
                    postId = postRepository.NewPost(postText, responseToPostId);
                }
                else
                {
                    hashTagRepository.RemoveTagsFromPost(postId.Value);
                    stockRepository.RemoveStockLinksFromPost(postId.Value);
                    postRepository.ModifyPost(postId.Value, postText);
                }
                hashTagRepository.AddTagsToPost(postId.Value, tags);
                stockRepository.LinkPostToStocks(postId.Value, stocks);
                transaction.Commit();
                return postRepository.GetPost(postId.Value);
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public PostModel LikeOrDislikePost(int postId, bool like)
        {
            return postRepository.LikeOrDislikePost(postId, like);
        }
    }
}