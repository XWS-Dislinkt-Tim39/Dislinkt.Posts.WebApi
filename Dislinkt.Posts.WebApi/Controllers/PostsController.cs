using Dislinkt.Posts.Application.Posts.NewPost;
using Dislinkt.Posts.Application.Posts.PostComment.Commands;
using Dislinkt.Posts.Application.Posts.PostDislike.Commands;
using Dislinkt.Posts.Application.Posts.PostLike.Commands;
using Dislinkt.Posts.Application.Posts.ShowPosts.Commands;
using Dislinkt.Posts.Domain.Posts;
using Grpc.Net.Client;
using GrpcAddActivityService;
using GrpcAddNotificationService;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OpenTracing;
using Newtonsoft.Json;
using System.IO;
using Dislinkt.Posts.Core.Repositories;
using Dislinkt.Posts.Persistance.MongoDB.Entities;
using Microsoft.AspNetCore.Http;

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
        private readonly ITracer _tracer;
        private readonly IPostRepository _postRepository;
        /// <summary>
        /// Init of controller
        /// </summary>
        public PostsController(IPostRepository postRepository,IMediator mediator, ITracer tracer)
        {
            _mediator = mediator;
            _tracer = tracer;
            _postRepository = postRepository;
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
        public async Task<Post> AddPostAsync(PostData postData)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);

            var newPost = await _mediator.Send(new NewPostCommand(postData));

            var channel = GrpcChannel.ForAddress("https://localhost:5002/");
            var client = new addNotificationGreeter.addNotificationGreeterClient(channel);

            foreach (string item in postData.followersId)
            {
                var reply = client.addNotification(new NotificationRequest { UserId =item, From = postData.UserId.ToString(), Type = "Post", Seen = false });

                if (!reply.Successful)
                {
                    Debug.WriteLine("Doslo je do greske prilikom kreiranja notifikacija za usera");
                    return null;
                }

                Debug.WriteLine("Uspesno prosledjen na registraciju u notifikacijama -- " + reply.Message);
            }

            var channel2 = GrpcChannel.ForAddress("https://localhost:5003/");
            var client2 = new addActivityGreeter.addActivityGreeterClient(channel2);
            var reply2 = client2.addActivity(new ActivityRequest { UserId = postData.UserId.ToString(), Text ="Created post", Type = "Post", Date = DateTime.Now.ToString() });

            if (!reply2.Successful)
            {
                Debug.WriteLine("Doslo je do greske prilikom kreiranja eventa za admina");
                return null;
            }

            Debug.WriteLine("Uspesno prosledjen na dashboard kod admina-- " + reply2.Message);

            return newPost;

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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            return await _mediator.Send(new AddCommentCommand(commentData));

        }
        /// <summary>
        /// Get all user posts
        /// </summary>
        /// <returns>All user posts</returns>
        /// /// <param name="id">for user</param>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/post")]
        public async Task<IReadOnlyList<Post>> GetUserPostsAsync(Guid id)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            return await _mediator.Send(new ShowPostsCommand(id));

        }
        /// <summary>
        /// Get all user posts
        /// </summary>
        /// <returns>All user posts</returns>
        /// /// <param name="image">for user</param>
        /// /// /// <param name="postId">for user</param>
        [HttpPost,DisableRequestSizeLimit]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/save-image/{postId}")]
        public Boolean SaveImage([FromForm]IFormFile image,[FromRoute]Guid postId)
        {
            if (image != null)
            {
                MemoryStream memoryStream=new MemoryStream();
                image.OpenReadStream().CopyTo(memoryStream);
                var imageString=Convert.ToBase64String(memoryStream.ToArray());

                _postRepository.SaveImage(postId, imageString);
                
            }
            return true;

        }
    }
}
