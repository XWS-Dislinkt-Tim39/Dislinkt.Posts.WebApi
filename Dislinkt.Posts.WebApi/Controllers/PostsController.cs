using Dislinkt.Posts.Application.Posts.NewPost;
using Dislinkt.Posts.Application.Posts.PostDislike.Commands;
using Dislinkt.Posts.Application.Posts.PostLike.Commands;
using Dislinkt.Posts.Application.Posts.ShowPosts.Commands;
using Dislinkt.Posts.Domain.Posts;
using MediatR;
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
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/add-post")]
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
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/remove-dislike")]
        public async Task<bool> RemoveDislikePostAsync(Guid userId, Guid postId)
        {
            return await _mediator.Send(new RemoveDislikeCommand(userId, postId));

        }
        /// <summary>
        /// Get all user posts
        /// </summary>
        /// <returns>All user posts</returns>
        /// /// <param name="id">for user</param>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/user-posts")]
        public async Task<IReadOnlyList<Post>> GetUserPostsAsync(Guid id)
        {
            return await _mediator.Send(new ShowPostsCommand(id));

        }
    }
}
