
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tiririt.Core.Collection;
using Tiririt.Core.Enums;
using Tiririt.Data.Entities;
using Tiririt.Data.Internal.Mappings;
using Tiririt.Data.Service;
using Tiririt.Domain.Models;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Tiririt.Core.Identity;

namespace Tiririt.Data.Internal.Service
{
    internal class TiriritPostRepository : ITiriritPostRepository
    {
        private readonly TiriritDbContext dbContext;
        private readonly ICurrentPrincipal currentPrincipal;

        public TiriritPostRepository(TiriritDbContext dbContext, ICurrentPrincipal currentPrincipal)
        {
            this.dbContext = dbContext;
            this.currentPrincipal = currentPrincipal;
        }

        public async Task DeletePost(int postId)
        {
            var post = await dbContext.TiriritPosts
                .SingleOrDefaultAsync(p => p.TIRIRIT_POST_ID == postId);
            if (post != null)
            {
                post.DELETED_IND = 1;                
                await dbContext.SaveChangesAsync();
            }            
        }

        private PostModel ToDomainModel(TIRIRIT_POST data)
        {
            return new PostModel
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
                        .Select(post => ToDomainModel(post))
            };
        }

        public IQueryable<PostModel> GetAll()
        {
            var result = dbContext.TiriritPosts
                .AsNoTracking()           
                .Where(post => post.DELETED_IND == 0)                     
                .Select(data => new PostModel
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
            
            return result;
        }

        public async Task<PostModel> GetPost(int postId)
        {
            var result = await GetAll()                
                .SingleOrDefaultAsync(post => post.PostId == postId);

            return result;
        }

        public async Task<PagingResultEnvelope<PostModel>> GetPostsByUserId(int userId, PagingParam pagingParam)
        {
            var result = GetAll()
                .Where(post => post.UserId == userId);
                        
            return await PagingResultEnvelope<PostModel>.ToPagingEnvelope(result, pagingParam);
        }

        public async Task<PagingResultEnvelope<PostModel>> GetResponses(int postId, PagingParam pagingParam)
        {
            var result = GetAll()
                .Where(post => post.ResponseToPostId == postId);
            return await PagingResultEnvelope<PostModel>.ToPagingEnvelope(result, pagingParam);
        }

        public async Task<IEnumerable<PostModel>> GetResponsesNoPaging(int postId)
        {
            var result = GetAll()
                .Where(post => post.ResponseToPostId == postId);
                
            return await result.ToListAsync();
        }

        public async Task<PostModel> LikeOrDislikePost(int postId, bool like)
        {
            // TODO get current user
            var userId = 1;
            // delete existing user like/dislike
            var existingRecord = await dbContext.LikeDislikePost
                .SingleOrDefaultAsync(l => l.TIRIRIT_USER_ID == userId && l.TIRIRIT_POST_ID == postId);
            
            if (existingRecord != null)
            {
                // toggle like/dislike
                var pastAction = existingRecord.USER_LIKE_IND == 1 ? true : false;
                if (pastAction == like)
                {
                    // withdraw the action by deleting
                    dbContext.LikeDislikePost.Remove(existingRecord);
                }
                else
                {
                    existingRecord.USER_LIKE_IND = like ? 1 : 0;
                }
            }
            else 
            {
                var newRecord = new LIKE_DISLIKE_POST
                {
                    TIRIRIT_POST_ID = postId,
                    TIRIRIT_USER_ID = userId,
                    USER_LIKE_IND = like ? 1 : 0
                };
                dbContext.LikeDislikePost.Add(newRecord);
            }
            await dbContext.SaveChangesAsync();
            return await GetPost(postId);
        }

        public async Task ModifyPost(int postId, string postText)
        {
            var post = await dbContext.TiriritPosts
                .SingleOrDefaultAsync(p => p.TIRIRIT_POST_ID == postId);
            
            if (post != null)
            {
                post.POST_TEXT = postText;
                post.MODIFIED_DATE = DateTime.Now;                
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<int> NewPost(string postText, BullBearLevel bullBearLevel, int? responseToPostId = null)
        {            
            var userId = this.currentPrincipal.GetUserId();
            var post = new TIRIRIT_POST 
            {
                BULL_BEAR_LEVEL_CODE_ID = (int)bullBearLevel,
                POST_DATE = DateTime.Now,
                POST_TEXT = postText,
                TIRIRIT_USER_ID = userId.Value,
                RESPONSE_TO_POST_ID = responseToPostId,
                DELETED_IND = 0
            };
            dbContext.TiriritPosts.Add(post);
            await dbContext.SaveChangesAsync();
            return post.TIRIRIT_POST_ID;
        }
    }
}