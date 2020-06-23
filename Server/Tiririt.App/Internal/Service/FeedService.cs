using System.Threading.Tasks;
using Tiririt.App.Service;
using Tiririt.Core.Collection;
using Tiririt.Data.Service;
using Tiririt.Domain.Models;

namespace Tiririt.App.Internal.Service
{
    public class FeedService : IFeedService
    {
        private readonly IFeedRepository feedRepository;

        public FeedService(IFeedRepository feedRepository)
        {
            this.feedRepository = feedRepository;
        }

        public async Task<PagingResultEnvelope<PostModel>> GetMentionFeed(PagingParam pagingParam)
        {
            return await this.feedRepository.GetMentionFeed(pagingParam);
        }

        public async Task<PagingResultEnvelope<PostModel>> GetPostsByStock(string symbol, PagingParam pagingParam)
        {
            return await this.feedRepository.GetPostsByStock(symbol, pagingParam);
        }

        public async Task<PagingResultEnvelope<PostModel>> GetPostsByTag(string tag, PagingParam pagingParam)
        {
            return await this.feedRepository.GetPostsByTag(tag, pagingParam);
        }

        public async Task<PagingResultEnvelope<PostModel>> GetSubscriptionFeed(PagingParam pagingParam)
        {
            return await this.feedRepository.GetSubscriptionFeed(pagingParam);
        }

        public async Task<PagingResultEnvelope<PostModel>> GetTrendingPosts(PagingParam pagingParam)
        {
            return await this.feedRepository.GetTrendingPosts(pagingParam);
        }

        public async Task<PagingResultEnvelope<PostModel>> GetUserFeed(PagingParam pagingParam)
        {
            return await feedRepository.GetUserFeed(pagingParam);
        }

        public async Task<PagingResultEnvelope<PostModel>> GetWatchListFeed(PagingParam pagingParam)
        {
            return await feedRepository.GetWatchListFeed(pagingParam);
        }

        public async Task<PagingResultEnvelope<PostModel>> Search(string searchText, PagingParam pagingParam)
        {
            return await feedRepository.Search(searchText, pagingParam);
        }
    }
}
