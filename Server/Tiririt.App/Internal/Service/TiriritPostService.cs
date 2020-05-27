using System.Collections.Generic;
using Tiririt.App.Service;
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

        public IEnumerable<PostModel> GetPostsByUserId(int userId)
        {
            //TODO paging
            var result = repository.GetPostsByUserId(userId);
            return result;
        }

        public IEnumerable<PostModel> GetResponses(int postId)
        {
            //TODO paging
            var result = repository.GetResponses(postId);
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