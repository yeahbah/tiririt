using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tiririt.App.Feed.Queries;
using Tiririt.App.Models;
using Tiririt.Core.Collection;
using Tiririt.Web.Common;

namespace Tiririt.Web.Controllers.Api
{
    [AllowAnonymous]
    public class PublicController : TiriritControllerBase
    {        
        private readonly IMediator mediator;

        public PublicController(IMediator mediator)
        {            
            this.mediator = mediator;
        }

        [HttpGet(RouteConsts.Feed.Trending)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetTrendingPosts([FromQuery]PagingParam pagingParam)
        {
            var result = await this.mediator.Send(new GetTrendingPostsQuery { PagingParam = pagingParam });
            return Ok(result);
        }


        [HttpGet(RouteConsts.Public.Search)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> Search([FromRoute]string searchText, [FromQuery]PagingParam pagingParam)
        {
            var result = await this.mediator.Send(new SearchFeedQuery { SearchText = searchText, PagingParam = pagingParam });
            return Ok(result);
        }

        [HttpGet(RouteConsts.Public.Tag)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetPostsByTag(string tag, [FromQuery]PagingParam pagingParam)
        {
            var result = await this.mediator.Send(new GetPostsByTagQuery { Tag = tag, PagingParam = pagingParam });
            return Ok(result);
        }

        [HttpGet(RouteConsts.Public.Stock)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetPostsByStock(string symbol, [FromQuery] PagingParam pagingParam)
        {
            var result = await this.mediator.Send(new GetPostsByStockQuery { StockSymbol = symbol, PagingParam = pagingParam });
            return Ok(result);
        }
    }
}
