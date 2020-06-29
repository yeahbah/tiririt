using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
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
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
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
        [HttpGet(RouteConsts.TiriritPost.UserPostings)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetPosts(int userId, PagingParam pagingParam)
        {
            var pagedResult = await tiriritPostService
                .GetPostsByUserId(userId, pagingParam);
            
            var data = pagedResult.Data
                .Select(post => post.ToViewModel());
                
            return Ok(new PagingResultEnvelope<PostViewModel>(data, pagedResult.TotalCount, pagingParam));
        }

        [AllowAnonymous]
        [HttpGet(RouteConsts.TiriritPost.PostDetails)]
        public async Task<IActionResult> GetPost(int postId)
        {
            var result = await tiriritPostService
                .GetPost(postId);

            return OkOrNotFound(result.ToViewModel());
        }

        /// <summary>
        /// New post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route(RouteConsts.TiriritPost.Post)]
        public async Task<ActionResult<PostViewModel>> NewPost([FromBody]NewPostViewModel newPostViewModel)
        {
            var result = await tiriritPostService
                .AddOrModifyPost(newPostViewModel.PostText, newPostViewModel.BullBearLevel);
                
            return Ok(result.ToViewModel());
        }

                
        [HttpPost(RouteConsts.TiriritPost.Reply)]
        public async Task<ActionResult<PostViewModel>> PostComment(int postId, [FromBody]string postText)
        {
            // TODO fix this
            var result = await tiriritPostService
                .AddOrModifyPost(postText, BullBearLevel.Neutral, null, postId);
            return Ok(result.ToViewModel());
        }

        /// <summary>
        /// Modifies a post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpPut(RouteConsts.TiriritPost.ModifyPost)]
        public async Task<ActionResult<PostViewModel>> ModifyPost(int postId, [FromBody]NewPostViewModel newPostViewModel)
        {
            var result = await tiriritPostService
                .AddOrModifyPost(newPostViewModel.PostText, newPostViewModel.BullBearLevel, postId);
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
        [AllowAnonymous]
        [HttpGet(RouteConsts.TiriritPost.Responses)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetResponses(
            int postId, [FromQuery]PagingParam pagingParam)
        {
            var pagedResult = await tiriritPostService
                .GetResponses(postId, pagingParam);
            var data = pagedResult.Data.Select(post => post.ToViewModel());                

            return Ok(new PagingResultEnvelope<PostViewModel>(data, pagedResult.TotalCount, pagingParam));
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