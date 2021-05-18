using System.Threading;
using System.Threading.Tasks;
using IdentityServer4;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tiririt.App.Models;
using Tiririt.App.Post.Commands;
using Tiririt.App.Post.Queries;
using Tiririt.Core.Collection;
using Tiririt.Web.Common;

namespace Tiririt.Web.Controllers
{
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    public class PostController : TiriritControllerBase
    {        
        private readonly IMediator mediator;

        public PostController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get all postings of a user
        /// </summary>
        /// <returns></returns>
        [HttpGet(RouteConsts.TiriritPost.UserPostings)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetPosts(int userId, PagingParam pagingParam, CancellationToken cancellationToken)
        {
            var result = await this.mediator.Send(new GetPostsByUserIdQuery { PagingParam = pagingParam, UserId = userId }, cancellationToken);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet(RouteConsts.TiriritPost.PostDetails)]
        public async Task<IActionResult> GetPost(int postId, CancellationToken cancellationToken)
        {
            var result = await this.mediator.Send(new GetPostQuery { PostId = postId }, cancellationToken);
            return OkOrNotFound(result);            
        }

        /// <summary>
        /// New post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route(RouteConsts.TiriritPost.Post)]
        public async Task<ActionResult<PostViewModel>> NewPost([FromBody]AddOrModifyPostCommand newPostCommand, CancellationToken cancellationToken)
        {
            var result = await this.mediator.Send(newPostCommand, cancellationToken);
            return Ok(result);
            //var result = await tiriritPostService
            //    .AddOrModifyPost(newPostViewModel.PostText, newPostViewModel.BullBearLevel);
                
            //return Ok(result.ToViewModel(this.currentPrincipal));
        }

                
        [HttpPost(RouteConsts.TiriritPost.Reply)]
        public async Task<ActionResult<PostViewModel>> PostComment([FromBody]PostCommentCommand postCommentCommand, CancellationToken cancellationToken)//(int postId, [FromBody]string postText)
        {
            var result = await mediator.Send(postCommentCommand, cancellationToken);
            return Ok(result);
                
            //var result = await tiriritPostService
            //    .AddOrModifyPost(postText, BullBearLevel.Neutral, null, postId);
            //return Ok(result.ToViewModel(this.currentPrincipal));
        }

        /// <summary>
        /// Modifies a post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpPut(RouteConsts.TiriritPost.ModifyPost)]
        public async Task<ActionResult<PostViewModel>> ModifyPost([FromBody]AddOrModifyPostCommand addOrModifyPostCommand, CancellationToken cancellationToken) //(int postId, [FromBody]NewPostViewModel newPostViewModel)
        {
            var result = await this.mediator.Send(addOrModifyPostCommand, cancellationToken);
            return Ok(result);
            //var result = await tiriritPostService
            //    .AddOrModifyPost(newPostViewModel.PostText, newPostViewModel.BullBearLevel, postId);
            //return Ok(result.ToViewModel(this.currentPrincipal));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(int postId, CancellationToken cancellationToken)
        {
            await this.mediator.Send(new DeletePostCommand(postId), cancellationToken);
            return Ok();            
        }        

        /// <summary>
        /// Returns the responses to a post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet(RouteConsts.TiriritPost.Comments)]
        public async Task<ActionResult<PagingResultEnvelope<PostViewModel>>> GetComments(
            int postId, [FromQuery]PagingParam pagingParam, CancellationToken cancellationToken)
        {
            var result = await this.mediator.Send(new GetCommentsQuery { PagingParam = pagingParam, PostId = postId }, cancellationToken);
            return Ok(result);
            //var pagedResult = await tiriritPostService
            //    .GetResponses(postId, pagingParam);
            //var data = pagedResult.Data.Select(post => post.ToViewModel(this.currentPrincipal));                

            //return Ok(new PagingResultEnvelope<PostViewModel>(data, pagedResult.TotalCount, pagingParam));
        }

        /// <summary>
        /// Like or dislike a post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="like"></param>
        /// <returns></returns>
        [HttpPut(RouteConsts.TiriritPost.LikeDislike)]
        public async Task<ActionResult<PostViewModel>> LikeDislike(LikeDislikeCommand likeDislikeCommand, CancellationToken cancellationToken)
        {
            var result = await this.mediator.Send(likeDislikeCommand, cancellationToken);
            return Ok(result);

            //var result = await tiriritPostService.LikeOrDislikePost(postId, like == 1 ? true : false);
            //return Ok(result.ToViewModel(this.currentPrincipal));
        }

    }
}