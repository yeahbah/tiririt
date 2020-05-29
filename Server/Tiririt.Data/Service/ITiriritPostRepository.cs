using System.Collections.Generic;
using Tiririt.Core.Collection;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Service
{
    public interface ITiriritPostRepository
    {
        void DeletePost(int postId);
        PagingResultEnvelope<PostModel> GetPostsByUserId(int userId, PagingParam pagingParam);
        int NewPost(string postText, int? responseToPostId = null);
        PostModel GetPost(int postId);
        PagingResultEnvelope<PostModel> GetResponses(int postId, PagingParam pagingParam);
        IEnumerable<PostModel> GetResponsesNoPaging(int postId);
        void ModifyPost(int postId, string postText);

        PostModel LikeOrDislikePost(int postId, bool like);
    }
}