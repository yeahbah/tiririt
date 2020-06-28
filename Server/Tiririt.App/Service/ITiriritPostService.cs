using System.Threading.Tasks;
using Tiririt.Core.Collection;
using Tiririt.Core.Enums;
using Tiririt.Domain.Models;

namespace Tiririt.App.Service
{
    public interface ITiriritPostService
    {
        Task<PagingResultEnvelope<PostModel>> GetPostsByUserId(int userId, PagingParam pagingParam);
        Task<PostModel> AddOrModifyPost(string postText, BullBearLevel bullBearLevel, int? postId = null, int? responseToPostId = null);
        Task DeletePost(int postId);
        Task<PagingResultEnvelope<PostModel>> GetResponses(int postId, PagingParam pagingParam);
        Task<PostModel> LikeOrDislikePost(int postId, bool like);
        Task<PostModel> GetPost(int postId);
    }
}