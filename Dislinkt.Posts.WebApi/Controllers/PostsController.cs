using Dislinkt.Posts.Application.Posts.NewPost;
using Dislinkt.Posts.Application.Posts.PostComment.Commands;
using Dislinkt.Posts.Application.Posts.PostDislike.Commands;
using Dislinkt.Posts.Application.Posts.PostLike.Commands;
using Dislinkt.Posts.Application.Posts.ShowPosts.Commands;
using Dislinkt.Posts.Domain.Posts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dislinkt.Posts.WebApi.Controllers
{
    /// <summary>
    /// Posts controler
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private const string ApiTag = "Posts";
        private readonly IMediator _mediator;
        /// <summary>
        /// Init of controller
        /// </summary>
        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Add new post
        /// </summary>
        /// <returns>Status of publishing post</returns>
        /// /// <param name="postData">for post</param>
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/post")]
        public async Task<bool> AddPostAsync(PostData postData)
        {
            return await _mediator.Send(new NewPostCommand(postData));

        }
        /// <summary>
        /// add Like to post
        /// </summary>
        /// <returns>bool</returns>
        /// /// <param name="userId">for user</param>
        /// /// <param name="postId">for post</param>
        [HttpGet]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/add-like")]
        public async Task<bool> AddLikePostAsync(Guid userId,Guid postId)
        {
            return await _mediator.Send(new AddLikePostCommand(userId,postId));

        }
        /// <summary>
        /// remove like from post
        /// </summary>
        /// <returns>bool</returns>
        /// /// <param name="userId">for user</param>
        /// /// <param name="postId">for post</param>
        [HttpGet]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/remove-like")]
        public async Task<bool> RemoveLikePostAsync(Guid userId, Guid postId)
        {
            return await _mediator.Send(new RemoveLikePostCommand(userId, postId));

        }
        /// <summary>
        /// add dislike to post
        /// </summary>
        /// <returns>bool</returns>
        /// /// <param name="userId">for user</param>
        /// /// <param name="postId">for post</param>
        [HttpGet]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/add-dislike")]
        public async Task<bool> AddDislikePostAsync(Guid userId, Guid postId)
        {
            return await _mediator.Send(new AddDislikeCommand(userId, postId));

        }
        /// <summary>
        /// remove dislike from post
        /// </summary>
        /// <returns>bool</returns>
        /// /// <param name="userId">for user</param>
        /// /// <param name="postId">for post</param>
        [HttpGet]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/remove-dislike")]
        public async Task<bool> RemoveDislikePostAsync(Guid userId, Guid postId)
        {
            return await _mediator.Send(new RemoveDislikeCommand(userId, postId));

        }

        /// <summary>
        /// Add new comment
        /// </summary>
        /// <returns>Status of publishing post</returns>
        /// /// <param name="commentData">for post</param>
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/add-comment")]
        public async Task<bool> AddCommentAsync(AddCommentData commentData)
        {
            return await _mediator.Send(new AddCommentCommand(commentData));

        }
        /// <summary>
        /// Get all user posts
        /// </summary>
        /// <returns>All user posts</returns>
        /// /// <param name="id">for user</param>
        [HttpGet]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/post")]
        public async Task<IReadOnlyList<Post>> GetUserPostsAsync(Guid id)
        {
            return await _mediator.Send(new ShowPostsCommand(id));

        }
    }
}
