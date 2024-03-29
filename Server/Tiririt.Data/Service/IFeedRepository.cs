﻿using System.Threading;
using System.Threading.Tasks;
using Tiririt.Core.Collection;
using Tiririt.Domain.Models;

namespace Tiririt.Data.Service
{
    public interface IFeedRepository
    {
        /// <summary>
        /// Returns all posts: mentions, subscriptions, watch list
        /// </summary>
        /// <param name="pagingParam"></param>
        /// <returns></returns>
        Task<PagingResultEnvelope<PostModel>> GetUserFeed(PagingParam pagingParam, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns posts that are trending
        /// </summary>
        /// <param name="pagingParam"></param>
        /// <returns></returns>
        Task<PagingResultEnvelope<PostModel>> GetTrendingPosts(PagingParam pagingParam, CancellationToken cancellationToken);

        /// <summary>
        /// Returns posts by stock
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="pagingParam"></param>
        /// <returns></returns>
        Task<PagingResultEnvelope<PostModel>> GetPostsByStock(string symbol, PagingParam pagingParam, CancellationToken cancellationToken);

        /// <summary>
        /// Returns posts by tag
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="pagingParam"></param>
        /// <returns></returns>
        Task<PagingResultEnvelope<PostModel>> GetPostsByTag(string tag, PagingParam pagingParam, CancellationToken cancellationToken);

        /// <summary>
        /// Returns posts that are in the user's watch list
        /// </summary>
        /// <param name="pagingParam"></param>
        /// <returns></returns>
        Task<PagingResultEnvelope<PostModel>> GetWatchListFeed(PagingParam pagingParam, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns posts that the user is mentioned
        /// </summary>
        /// <param name="pagingParam"></param>
        /// <returns></returns>
        Task<PagingResultEnvelope<PostModel>> GetMentionFeed(PagingParam pagingParam, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns posts that the user is subscribed to
        /// </summary>
        /// <param name="pagingParam"></param>
        /// <returns></returns>
        Task<PagingResultEnvelope<PostModel>> GetSubscriptionFeed(PagingParam pagingParam, CancellationToken cancellationToken);

        /// <summary>
        /// Search posts
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="pagingParam"></param>
        /// <returns></returns>
        Task<PagingResultEnvelope<PostModel>> Search(string searchText, PagingParam pagingParam, CancellationToken cancellationToken);
    }
}
