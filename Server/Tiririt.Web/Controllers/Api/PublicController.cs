using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Tiririt.App.Service;
using Tiririt.Core.Collection;
using Tiririt.Web.Common;
using Tiririt.Web.Models;
using Tiririt.Web.Models.Mappings;

namespace Tiririt.Web.Controllers.Api
{
    [AllowAnonymous]
    public class PublicController : TiriritControllerBase
    {
        private readonly IFeedService feedService;

        public PublicController(IFeedService feedService)
        {
            this.feedService = feedService;
        }

        [HttpGet(RouteConsts.Feed.Trending)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetTrendingPosts([FromRoute]PagingParam pagingParam)
        {
            var pagedResult = await this.feedService.GetTrendingPosts(pagingParam);
            var result = pagedResult.Data.Select(post => post.ToViewModel());

            return Ok(new PagingResultEnvelope<PostViewModel>(result, pagedResult.TotalCount, pagingParam));
        }

    }
}
