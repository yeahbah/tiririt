using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tiririt.App.Service;
using Tiririt.Core.Collection;
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
        [HttpGet("user/{userId}")]
        public ActionResult<PagingResultEnvelope<PostViewModel>> GetPosts(int userId, PagingParam pagingParam)
        {
            var result = tiriritPostService
                .GetPostsByUserId(userId, pagingParam)                
                .Data.Select(post => post.ToViewModel())
                .AsQueryable();
                
            return Ok(PagingResultEnvelope<PostViewModel>.ToPagingEnvelope(result, pagingParam));
        }

        /// <summary>
        /// New post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<PostViewModel> NewPost([FromBody]string postText)
        {
            var result = tiriritPostService
                .NewPost(postText)
                .ToViewModel();
            return Ok(result);
        }

                
        [HttpPost("{postId}/reply")]
        public ActionResult<PostViewModel> NewResponse(int postId, [FromBody]string postText)
        {
            var result = tiriritPostService
                .NewPost(postText, postId)
                .ToViewModel();
            return Ok(result);
        }

        /// <summary>
        /// Modifies a post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpPut("{postId}")]
        public ActionResult<PostViewModel> ModifyPost(int postId, [FromBody]string postText)
        {
            var result = tiriritPostService
                .ModifyPost(postId, postText)
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
        [HttpGet("{postId}/responses")]
        public ActionResult<PagingResultEnvelope<ResponseViewModel>> GetResponses(int postId, PagingParam pagingParam)
        {
            var result = tiriritPostService
                .GetResponses(postId, pagingParam)
                .Data.Select(post => post.ToResponseViewModel())
                .AsQueryable();
            return Ok(PagingResultEnvelope<ResponseViewModel>.ToPagingEnvelope(result, pagingParam));
        }

    }
}