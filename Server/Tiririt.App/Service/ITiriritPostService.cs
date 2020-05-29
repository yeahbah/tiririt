using Tiririt.Core.Collection;
using Tiririt.Domain.Models;

namespace Tiririt.App.Service
{
    public interface ITiriritPostService
    {
        PagingResultEnvelope<PostModel> GetPostsByUserId(int userId, PagingParam pagingParam);
        PostModel NewPost(string postText, int? responseToPostId = null);
        PostModel ModifyPost(int postId, string postText);
        void DeletePost(int postId);
        PagingResultEnvelope<PostModel> GetResponses(int postId, PagingParam pagingParam);
    }
}