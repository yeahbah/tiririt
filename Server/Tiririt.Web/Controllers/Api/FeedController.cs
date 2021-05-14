using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tiririt.App.Service;
using Tiririt.Core.Collection;
using Tiririt.Core.Identity;
using Tiririt.Web.Common;
using MediatR;
using Tiririt.App.Feed.Queries;
using Tiririt.App.Models;

namespace Tiririt.Web.Controllers.Api
{
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    public class FeedController : TiriritControllerBase
    {
        private readonly IMediator mediator;

        public FeedController(IMediator mediator)
        {            
            this.mediator = mediator;
        }

        /// <summary>
        /// Returns all the posts the user is linked to, e.g. mentions, watchlist, subscriptions
        /// </summary>
        /// <returns></returns>
        [HttpGet(RouteConsts.Feed.UserFeed)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetUserFeed([FromQuery]PagingParam pagingParam)
        {
            var result = await this.mediator.Send(new GetUserFeedQuery { PagingParam = pagingParam });
            return Ok(result);
        }

        /// <summary>
        /// Returns all the posts that are related to the user's watch list.
        /// </summary>
        /// <param name="pagingParam"></param>
        /// <returns></returns>
        [HttpGet(RouteConsts.Feed.WatchList)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetWatchListFeed([FromQuery]PagingParam pagingParam)
        {
            var result = await this.mediator.Send(new GetWatchListFeedQuery { PagingParam = pagingParam });
            return Ok(result);
        }

        /// <summary>
        /// Returns all the posts the user is mentioned in
        /// </summary>
        /// <param name="pagingParam"></param>
        /// <returns></returns>
        [HttpGet(RouteConsts.Feed.Mentions)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetMentionsFeed([FromQuery]PagingParam pagingParam)
        {
            var result = await this.mediator.Send(new GetMentionsFeedQuery { PagingParam = pagingParam });
            return Ok(result);
        }

        [HttpGet(RouteConsts.Feed.Subscription)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetSubscriptionFeed([FromQuery]PagingParam pagingParam)
        {
            var result = await this.mediator.Send(new GetSubscriptionFeedQuery { PagingParam = pagingParam });
            return Ok(result);
        }


    }
}
