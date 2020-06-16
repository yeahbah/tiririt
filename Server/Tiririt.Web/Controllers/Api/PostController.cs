using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tiririt.App.Service;
using Tiririt.Core.Collection;
using Tiririt.Core.Enums;
using Tiririt.Web.Common;
using Tiririt.Web.Models;
using Tiririt.Web.Models.Mappings;

namespace Tiririt.Web.Controllers
{
    public class PostController : TiriritControllerBase
    {
        private readonly ITiriritPostService tiriritPostService;

        public PostController(ITiriritPostService tiriritPostService)
        {
            this.tiriritPostService = tiriritPostService;
        }

        /// <summary>
        /// Get all postings of a user
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet(RouteConsts.TiriritPost.UserPostings)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetPosts(int userId, PagingParam pagingParam)
        {
            var pagedResult = await tiriritPostService
                .GetPostsByUserId(userId, pagingParam);
            
            var data = pagedResult.Data
                .Select(post => post.ToViewModel());
                
            return Ok(new PagingResultEnvelope<PostViewModel>(data, pagedResult.TotalCount, pagingParam));
        }

        /// <summary>
        /// New post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PostViewModel>> NewPost([FromBody]string postText, BullBearLevel? bullBearLevel)
        {
            var result = await tiriritPostService
                .AddOrModifyPost(postText);
                
            return Ok(result.ToViewModel());
        }

                
        [HttpPost(RouteConsts.TiriritPost.Reply)]
        public async Task<ActionResult<PostViewModel>> NewResponse(int postId, [FromBody]string postText)
        {
            var result = await tiriritPostService
                .AddOrModifyPost(postText, null, postId);
            return Ok(result.ToViewModel());
        }

        /// <summary>
        /// Modifies a post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpPut(RouteConsts.TiriritPost.ModifyPost)]
        public async Task<ActionResult<PostViewModel>> ModifyPost(int postId, [FromBody]string postText)
        {
            var result = await tiriritPostService
                .AddOrModifyPost(postText, postId);
            return Ok(result.ToViewModel());
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(int postId)
        {
            await tiriritPostService.DeletePost(postId);
            return Ok();
        }        

        /// <summary>
        /// Returns the responses to a post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet(RouteConsts.TiriritPost.Responses)]
        public async Task<ActionResult<PagingResultEnvelope<ResponseViewModel>>> GetResponses(int postId, PagingParam pagingParam)
        {
            var pagedResult = await tiriritPostService
                .GetResponses(postId, pagingParam);
            var data = pagedResult.Data.Select(post => post.ToResponseViewModel());                

            return Ok(new PagingResultEnvelope<ResponseViewModel>(data, pagedResult.TotalCount, pagingParam));
        }

        /// <summary>
        /// Like or dislike a post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="like"></param>
        /// <returns></returns>
        [HttpGet(RouteConsts.TiriritPost.LikeDislike)]
        public async Task<ActionResult<PostViewModel>> LikeDislike(int postId, int like)
        {
            var result = await tiriritPostService.LikeOrDislikePost(postId, like == 1 ? true : false);
            return Ok(result.ToViewModel());
        }

    }
}