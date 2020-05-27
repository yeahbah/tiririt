using System.Collections.Generic;
using Tiririt.Domain.Models;

namespace Tiririt.App.Service
{
    public interface ITiriritPostService
    {
        IEnumerable<PostModel> GetPostsByUserId(int userId);
        PostModel NewPost(string postText, int? responseToPostId = null);
        PostModel ModifyPost(int postId, string postText);
        void DeletePost(int postId);
        IEnumerable<PostModel> GetResponses(int postId);
    }
}