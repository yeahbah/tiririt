using System.Threading.Tasks;
using Tiririt.Core.Collection;
using Tiririt.Domain.Models;

namespace Tiririt.App.Service
{
    public interface IFeedService
    {
        /// <summary>
        /// Returns all posts: mentions, subscriptions, watch list
        /// </summary>
        /// <param name="pagingParam"></param>
        /// <returns></returns>
        Task<PagingResultEnvelope<PostModel>> GetUserFeed(PagingParam pagingParam);

        /// <summary>
        /// Returns posts that are trending
        /// </summary>
        /// <param name="pagingParam"></param>
        /// <returns></returns>
        Task<PagingResultEnvelope<PostModel>> GetTrendingPosts(PagingParam pagingParam);

        /// <summary>
        /// Returns posts that are in the user's watch list
        /// </summary>
        /// <param name="pagingParam"></param>
        /// <returns></returns>
        Task<PagingResultEnvelope<PostModel>> GetWatchListFeed(PagingParam pagingParam);

        /// <summary>
        /// Returns posts that the user is mentioned
        /// </summary>
        /// <param name="pagingParam"></param>
        /// <returns></returns>
        Task<PagingResultEnvelope<PostModel>> GetMentionFeed(PagingParam pagingParam);

        /// <summary>
        /// Returns posts that the user is subscribed to
        /// </summary>
        /// <param name="pagingParam"></param>
        /// <returns></returns>
        Task<PagingResultEnvelope<PostModel>> GetSubscriptionFeed(PagingParam pagingParam);

        /// <summary>
        /// Search posts
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="pagingParam"></param>
        /// <returns></returns>
        Task<PagingResultEnvelope<PostModel>> Search(string searchText, PagingParam pagingParam);
        
    }
}
