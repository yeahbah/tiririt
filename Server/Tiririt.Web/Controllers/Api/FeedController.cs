using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Tiririt.App.Service;
using Tiririt.Core.Collection;
using Tiririt.Core.Identity;
using Tiririt.Web.Common;
using Tiririt.Web.Models;
using Tiririt.Web.Models.Mappings;

namespace Tiririt.Web.Controllers.Api
{
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    public class FeedController : TiriritControllerBase
    {
        private readonly IFeedService feedService;
        private readonly ICurrentPrincipal currentPrincipal;

        public FeedController(IFeedService feedService, ICurrentPrincipal currentPrincipal)
        {
            this.feedService = feedService;
            this.currentPrincipal = currentPrincipal;
        }

        /// <summary>
        /// Returns all the posts the user is linked to, e.g. mentions, watchlist, subscriptions
        /// </summary>
        /// <returns></returns>
        [HttpGet(RouteConsts.Feed.UserFeed)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetUserFeed([FromQuery]PagingParam pagingParam)
        {
            var pagedResult = await this.feedService.GetUserFeed(pagingParam);
            var data = pagedResult.Data.Select(post => post.ToViewModel(this.currentPrincipal));

            return Ok(new PagingResultEnvelope<PostViewModel>(data, pagedResult.TotalCount, pagingParam));
        }

        [HttpGet(RouteConsts.Feed.WatchList)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetWatchListFeed([FromQuery]PagingParam pagingParam)
        {
            var pagedResult = await this.feedService.GetWatchListFeed(pagingParam);
            var data = pagedResult.Data.Select(post => post.ToViewModel(this.currentPrincipal));

            return Ok(new PagingResultEnvelope<PostViewModel>(data, pagedResult.TotalCount, pagingParam));
        }

        [HttpGet(RouteConsts.Feed.Mentions)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetMentionsFeed([FromQuery]PagingParam pagingParam)
        {
            var pagedResult = await this.feedService.GetMentionFeed(pagingParam);
            var data = pagedResult.Data.Select(post => post.ToViewModel(this.currentPrincipal));

            return Ok(new PagingResultEnvelope<PostViewModel>(data, pagedResult.TotalCount, pagingParam));
        }

        [HttpGet(RouteConsts.Feed.Subscription)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetSubscriptionFeed([FromQuery]PagingParam pagingParam)
        {
            var pagedResult = await this.feedService.GetSubscriptionFeed(pagingParam);
            var data = pagedResult.Data.Select(post => post.ToViewModel(this.currentPrincipal));

            return Ok(new PagingResultEnvelope<PostViewModel>(data, pagedResult.TotalCount, pagingParam));
        }


    }
}
