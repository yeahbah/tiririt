using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tiririt.Core.Collection;
using Tiririt.Core.Identity;
using Tiririt.Data.Entities;
using Tiririt.Data.Internal.Mappings;
using Tiririt.Data.Service;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Internal.Service
{
    public class FeedRepository : IFeedRepository
    {
        private readonly TiriritDbContext dbContext;
        private readonly ICurrentPrincipal currentPrincipal;

        public FeedRepository(TiriritDbContext dbContext, 
            ITiriritPostRepository tiriritPostRepository,
            ICurrentPrincipal currentPrincipal)
        {
            this.dbContext = dbContext;
            this.currentPrincipal = currentPrincipal;
        }

        private IQueryable<PostModel> ToDomainModel(IQueryable<TIRIRIT_POST> source)
        {
            return source.Select(data => new PostModel
            {
                PostId = data.TIRIRIT_POST_ID,
                ModifiedDate = data.MODIFIED_DATE,
                PostDate = data.POST_DATE,
                PostText = data.POST_TEXT,
                UserId = data.TIRIRIT_USER_ID,
                UserName = data.Ref_PostedBy.UserName,
                ResponseToPostId = data.RESPONSE_TO_POST_ID,

                BullBearLevel = data.Ref_BullBearLevel.BULL_BEAR_LEVEL_CD,

                DislikedBy = data.Ref_LikeDislikeByUsers
                        .Where(like => like.USER_LIKE_IND == 0)
                        .Select(l => l.Ref_TiriritUser.ToDomainModel()),

                LikedBy = data.Ref_LikeDislikeByUsers
                        .Where(like => like.USER_LIKE_IND == 1)
                        .Select(l => l.Ref_TiriritUser.ToDomainModel()),

                RelatedStocks = data.Ref_Stocks
                        .Where(stock => stock.DELETED_IND == 0)
                        .Select(stock => new StockModel
                        {
                            Name = stock.Ref_Stock.NAME,
                            SectorId = stock.Ref_Stock.SECTOR_ID,
                            StockId = stock.Ref_Stock.STOCK_ID,
                            StockQuotes = stock.Ref_Stock.Ref_StockQuotes
                                .Select(q => q.ToDomainModel()),
                            Symbol = stock.Ref_Stock.SYMBOL
                        }),

                Tags = data.Ref_HashTags
                        .Where(tag => tag.DELETED_IND == 0)
                        .Select(tag => tag.Ref_HashTag.ToDomainModel()),

                Comments = data.Ref_Responses
                        .Select(comment => new PostModel
                        {
                            PostId = comment.TIRIRIT_POST_ID,
                            ModifiedDate = comment.MODIFIED_DATE,
                            PostDate = comment.POST_DATE,
                            PostText = comment.POST_TEXT,
                            UserId = comment.TIRIRIT_USER_ID,
                            UserName = comment.Ref_PostedBy.UserName,
                            ResponseToPostId = comment.RESPONSE_TO_POST_ID,

                            BullBearLevel = comment.Ref_BullBearLevel.BULL_BEAR_LEVEL_CD,

                            DislikedBy = comment.Ref_LikeDislikeByUsers
                                .Where(like => like.USER_LIKE_IND == 0)
                                .Select(l => l.Ref_TiriritUser.ToDomainModel()),

                            LikedBy = comment.Ref_LikeDislikeByUsers
                                .Where(like => like.USER_LIKE_IND == 1)
                                .Select(l => l.Ref_TiriritUser.ToDomainModel()),

                            RelatedStocks = comment.Ref_Stocks
                                .Where(stock => stock.DELETED_IND == 0)
                                .Select(stock => new StockModel
                                {
                                    Name = stock.Ref_Stock.NAME,
                                    SectorId = stock.Ref_Stock.SECTOR_ID,
                                    StockId = stock.Ref_Stock.STOCK_ID,
                                    StockQuotes = stock.Ref_Stock.Ref_StockQuotes
                                        .Select(q => q.ToDomainModel()),
                                    Symbol = stock.Ref_Stock.SYMBOL
                                }),

                            Tags = comment.Ref_HashTags
                                .Where(tag => tag.DELETED_IND == 0)
                                .Select(tag => tag.Ref_HashTag.ToDomainModel()),
                        })
            });
        }

        public IQueryable<TIRIRIT_POST> GetAll()
        {
            var result = dbContext.TiriritPosts
                .AsNoTracking()
                .Where(post => post.DELETED_IND == 0);
                              
            return result;
        }

        public async Task<PagingResultEnvelope<PostModel>> GetMentionFeed(PagingParam pagingParam)
        {
            var userId = this.currentPrincipal.GetUserId();
            var query = GetAll()
                // get all posts the user is mentioned in
                .Where(post => post.Ref_MentionUsers.Any(mention => mention.TIRIRIT_USER_ID == userId && mention.Ref_TiriritPost.DELETED_IND == 0)
                    || post.Ref_Responses.Any(response => response.Ref_MentionUsers.Any(mention => mention.TIRIRIT_USER_ID == userId) && response.DELETED_IND == 0))
                .Distinct()
                .OrderByDescending(o => o.POST_DATE);

            return await PagingResultEnvelope<PostModel>.ToPagingEnvelope(ToDomainModel(query), pagingParam);
        }

        public async Task<PagingResultEnvelope<PostModel>> GetSubscriptionFeed(PagingParam pagingParam)
        {
            // TODO
            var query = GetAll()
                            .OrderByDescending(o => o.POST_DATE);

            return await PagingResultEnvelope<PostModel>.ToPagingEnvelope(ToDomainModel(query), pagingParam);
        }

        public async Task<PagingResultEnvelope<PostModel>> GetTrendingPosts(PagingParam pagingParam)
        {
            var query = GetAll()
                .OrderByDescending(o => o.POST_DATE);

            return await PagingResultEnvelope<PostModel>.ToPagingEnvelope(ToDomainModel(query), pagingParam);
        }

        public async Task<PagingResultEnvelope<PostModel>> GetUserFeed(PagingParam pagingParam)
        {
            var userId = this.currentPrincipal.GetUserId();
            var query = GetAll()
                // get all posts the user is mentioned in
                // get all posts the user responded to
                // get all posts related to the users watch list
                // TODO include subscriptions
                .Where(post => post.TIRIRIT_USER_ID == userId 
                    || post.Ref_MentionUsers.Any(mention => mention.TIRIRIT_USER_ID == userId && mention.Ref_TiriritPost.DELETED_IND == 0)
                    || post.Ref_Responses.Any(response => response.TIRIRIT_USER_ID == userId && response.DELETED_IND == 0)
                    || post.Ref_Stocks.Any(
                        stock => stock.Ref_Stock.Ref_StocksInWatchLists.Any(w => w.STOCK_ID == stock.STOCK_ID && w.Ref_WatchList.TIRIRIT_USER_ID == userId)))
                
                .Distinct()
                .OrderByDescending(o => o.POST_DATE);
                
            return await PagingResultEnvelope<PostModel>.ToPagingEnvelope(ToDomainModel(query), pagingParam);
        }

        public async Task<PagingResultEnvelope<PostModel>> GetWatchListFeed(PagingParam pagingParam)
        {
            var userId = this.currentPrincipal.GetUserId();
            var query = GetAll()
                .Where(post => post.Ref_Stocks.Any(
                            stock => stock.Ref_Stock.Ref_StocksInWatchLists.Any(w => w.STOCK_ID == stock.STOCK_ID && w.Ref_WatchList.TIRIRIT_USER_ID == userId)))
                .Distinct()
                .OrderByDescending(o => o.POST_DATE);

            return await PagingResultEnvelope<PostModel>.ToPagingEnvelope(ToDomainModel(query), pagingParam);
        }

        public async Task<PagingResultEnvelope<PostModel>> Search(string searchText, PagingParam pagingParam)
        {
            var query = GetAll();
            return await PagingResultEnvelope<PostModel>.ToPagingEnvelope(ToDomainModel(query), pagingParam);
        }

        public async Task<PagingResultEnvelope<PostModel>> GetPostsByStock(string symbol, PagingParam pagingParam)
        {
            var query = GetAll()
                .Where(post => post.Ref_Stocks.Any(stock => stock.Ref_Stock.SYMBOL == symbol))
                .OrderByDescending(o => o.POST_DATE);

            return await PagingResultEnvelope<PostModel>.ToPagingEnvelope(ToDomainModel(query), pagingParam);
        }

        public async Task<PagingResultEnvelope<PostModel>> GetPostsByTag(string tag, PagingParam pagingParam)
        {
            var query = GetAll()
                .Where(post => post.Ref_HashTags.Any(hashTag => hashTag.Ref_HashTag.HASH_TAG_TEXT == tag))
                .OrderByDescending(o => o.POST_DATE);

            return await PagingResultEnvelope<PostModel>.ToPagingEnvelope(ToDomainModel(query), pagingParam);
        }
    }
}
