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

namespace Tiririt.Data.Internal.Service
{
    internal class TiriritPostRepository : ITiriritPostRepository
    {
        private readonly TiriritDbContext dbContext;

        public TiriritPostRepository(TiriritDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void DeletePost(int postId)
        {
            var post = dbContext.TiriritPosts
                .SingleOrDefault(p => p.TIRIRIT_POST_ID == postId);
            if (post != null)
            {
                post.DELETED_IND = 1;                
                dbContext.SaveChanges();
            }            
        }

        public IQueryable<PostModel> GetAll()
        {
            var result = dbContext.TiriritPosts
                .AsNoTracking()           
                .Where(post => post.DELETED_IND == 0)                     
                .Select(data => new PostModel {
                    PostId = data.TIRIRIT_POST_ID,
                    ModifiedDate = data.MODIFIED_DATE,
                    PostDate = data.POST_DATE,
                    PostText = data.POST_TEXT,
                    UserId = data.TIRIRIT_USER_ID,                    
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
                        .Select(stock => stock.Ref_Stock.ToDomainModel()),
                    
                    Tags = data.Ref_HashTags
                        .Where(tag => tag.DELETED_IND == 0)
                        .Select(tag => tag.Ref_HashTag.ToDomainModel())                                        
                });
            
            return result;
        }

        public PostModel GetPost(int postId)
        {
            var result = GetAll()                
                .SingleOrDefault(post => post.PostId == postId);

            return result;
        }

        public PagingResultEnvelope<PostModel> GetPostsByUserId(int userId, PagingParam pagingParam)
        {
            var result = GetAll()
                .Where(post => post.UserId == userId);
                        
            return PagingResultEnvelope<PostModel>.ToPagingEnvelope(result, pagingParam);
        }

        public PagingResultEnvelope<PostModel> GetResponses(int postId, PagingParam pagingParam)
        {
            var result = GetAll()
                .Where(post => post.ResponseToPostId == postId);
            return PagingResultEnvelope<PostModel>.ToPagingEnvelope(result, pagingParam);
        }

        public IEnumerable<PostModel> GetResponsesNoPaging(int postId)
        {
            var result = GetAll()
                .Where(post => post.ResponseToPostId == postId);
                
            return result.ToList();
        }

        public PostModel LikeOrDislikePost(int postId, bool like)
        {
            // TODO get current user
            var userId = 2;
            // delete existing user like/dislike
            var existingRecord = dbContext.LikeDislikePost
                .SingleOrDefault(l => l.TIRIRIT_USER_ID == userId && l.TIRIRIT_POST_ID == postId);
            
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
            dbContext.SaveChanges();
            return GetPost(postId);
        }

        public void ModifyPost(int postId, string postText)
        {
            var post = dbContext.TiriritPosts
                .SingleOrDefault(p => p.TIRIRIT_POST_ID == postId);
            
            if (post != null)
            {
                post.POST_TEXT = postText;
                post.MODIFIED_DATE = DateTime.Now;                
                dbContext.SaveChanges();
            }
        }

        public int NewPost(string postText, int? responseToPostId = null)
        {
            // TODO current user 
            var post = new TIRIRIT_POST 
            {
                BULL_BEAR_LEVEL_CODE_ID = (int)BullBearLevel.Neutral,
                POST_DATE = DateTime.Now,
                POST_TEXT = postText,
                TIRIRIT_USER_ID = 2,
                RESPONSE_TO_POST_ID = responseToPostId,
                DELETED_IND = 0
            };
            dbContext.TiriritPosts.Add(post);
            dbContext.SaveChanges();
            return post.TIRIRIT_POST_ID;
        }
    }
}