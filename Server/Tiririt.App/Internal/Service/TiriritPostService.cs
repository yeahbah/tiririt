using System.Collections.Generic;
using Tiririt.App.Service;
using Tiririt.Core.Collection;
using Tiririt.Data.Service;
using Tiririt.Domain.Models;

namespace Tiririt.App.Internal.Service
{
    public class TiriritPostService : ITiriritPostService
    {
        private readonly ITiriritPostRepository repository;

        public TiriritPostService(ITiriritPostRepository repository)
        {
            this.repository = repository;
        }

        public void DeletePost(int postId)
        {
            //TODO validate if user can delete
            repository.DeletePost(postId);
        }

        public PagingResultEnvelope<PostModel> GetPostsByUserId(int userId, PagingParam pagingParam)
        {
            var result = repository.GetPostsByUserId(userId, pagingParam);
            return result;
        }

        public PagingResultEnvelope<PostModel> GetResponses(int postId, PagingParam pagingParam)
        {
            var result = repository.GetResponses(postId, pagingParam);
            return result;
        }    

        public PostModel ModifyPost(int postId, string postText)
        {
            repository.ModifyPost(postId, postText);
            return repository.GetPost(postId);
        }

        public PostModel NewPost(string postText, int? responseToPostId = null)
        {
            var postId = repository.NewPost(postText, responseToPostId);
            return repository.GetPost(postId);
        }
    }
}