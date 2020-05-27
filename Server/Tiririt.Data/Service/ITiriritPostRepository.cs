using System.Collections.Generic;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Service
{
    public interface ITiriritPostRepository
    {
        void DeletePost(int postId);
        IEnumerable<PostModel> GetPostsByUserId(int userId);
        int NewPost(string postText, int? responseToPostId = null);
        PostModel GetPost(int postId);
        IEnumerable<PostModel> GetResponses(int postId);
        void ModifyPost(int postId, string postText);
    }
}