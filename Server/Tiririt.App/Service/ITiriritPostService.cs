using Tiririt.Core.Collection;
using Tiririt.Domain.Models;

namespace Tiririt.App.Service
{
    public interface ITiriritPostService
    {
        PagingResultEnvelope<PostModel> GetPostsByUserId(int userId, PagingParam pagingParam);
        PostModel AddOrModifyPost(string postText, int? postId = null, int? responseToPostId = null);
        void DeletePost(int postId);
        PagingResultEnvelope<PostModel> GetResponses(int postId, PagingParam pagingParam);
        PostModel LikeOrDislikePost(int postId, bool like);
    }
}