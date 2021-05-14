using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tiririt.Core.Collection;
using Tiririt.Core.Enums;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Service
{
    public interface ITiriritPostRepository
    {
        IQueryable<PostModel> GetAll();

        Task DeletePost(int postId);
        Task<PagingResultEnvelope<PostModel>> GetPostsByUserId(int userId, PagingParam pagingParam, CancellationToken cancellationToken = default);
        Task<int> NewPost(string postText, BullBearLevel bullBearLevel, int? responseToPostId = null);
        Task<PostModel> GetPost(int postId, CancellationToken cancellationToken = default);
        Task<PagingResultEnvelope<PostModel>> GetComments(int postId, PagingParam pagingParam, CancellationToken cancellationToken = default);
        Task<IEnumerable<PostModel>> GetResponsesNoPaging(int postId);
        Task ModifyPost(int postId, string postText);

        Task<PostModel> LikeOrDislikePost(int postId, bool like, CancellationToken cancellationToken = default);
    }
}