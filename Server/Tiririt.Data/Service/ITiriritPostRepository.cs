using System.Collections.Generic;
using System.Threading.Tasks;
using Tiririt.Core.Collection;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Service
{
    public interface ITiriritPostRepository
    {
        Task DeletePost(int postId);
        Task<PagingResultEnvelope<PostModel>> GetPostsByUserId(int userId, PagingParam pagingParam);
        Task<int> NewPost(string postText, int? responseToPostId = null);
        Task<PostModel> GetPost(int postId);
        Task<PagingResultEnvelope<PostModel>> GetResponses(int postId, PagingParam pagingParam);
        Task<IEnumerable<PostModel>> GetResponsesNoPaging(int postId);
        Task ModifyPost(int postId, string postText);

        Task<PostModel> LikeOrDislikePost(int postId, bool like);
    }
}