using System.Linq;
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
        [HttpGet(RouteConsts.TiriritPost.UserPostings)]
        public ActionResult<PagingResultEnvelope<PostViewModel>> GetPosts(int userId, PagingParam pagingParam)
        {
            var pagedResult = tiriritPostService
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
        public ActionResult<PostViewModel> NewPost([FromBody]string postText, BullBearLevel? bullBearLevel)
        {
            var result = tiriritPostService
                .AddOrModifyPost(postText)
                .ToViewModel();
            return Ok(result);
        }

                
        [HttpPost(RouteConsts.TiriritPost.Reply)]
        public ActionResult<PostViewModel> NewResponse(int postId, [FromBody]string postText)
        {
            var result = tiriritPostService
                .AddOrModifyPost(postText, null, postId)
                .ToViewModel();
            return Ok(result);
        }

        /// <summary>
        /// Modifies a post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpPut(RouteConsts.TiriritPost.ModifyPost)]
        public ActionResult<PostViewModel> ModifyPost(int postId, [FromBody]string postText)
        {
            var result = tiriritPostService
                .AddOrModifyPost(postText, postId)
                .ToViewModel();
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeletePost(int postId)
        {
            tiriritPostService.DeletePost(postId);
            return Ok();
        }        

        /// <summary>
        /// Returns the responses to a post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet(RouteConsts.TiriritPost.Responses)]
        public ActionResult<PagingResultEnvelope<ResponseViewModel>> GetResponses(int postId, PagingParam pagingParam)
        {
            var pagedResult = tiriritPostService
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
        public ActionResult<PostViewModel> LikeDislike(int postId, int like)
        {
            var result = tiriritPostService.LikeOrDislikePost(postId, like == 1 ? true : false);
            return Ok(result.ToViewModel());
        }

    }
}