﻿using Dislinkt.Posts.Core.Repositories;
using Dislinkt.Posts.Domain.Posts;
using Dislinkt.Posts.Persistance.MongoDB.Common;
using Dislinkt.Posts.Persistance.MongoDB.Entities;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dislinkt.Posts.Domain.Users;
using Dislinkt.Posts.Domain.Comments;

namespace Dislinkt.Posts.Persistance.MongoDB.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IQueryExecutor _queryExecutor;
        public PostRepository(IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task AddAsync(Post post)
        {
            try
            {
                await _queryExecutor.CreateAsync(PostEntity.ToPostEntity(post));

            } catch(MongoWriteException ex)
            {
                throw ex;
            }
        }

        public async Task<Guid> CreateAsync(UserPosts userPosts)
        {
            try
            {
                await _queryExecutor.CreateAsync(UserPostsEntity.ToUserPostsEntity(userPosts));
                var id = userPosts.Id;
                return userPosts.Id;
            } catch(MongoWriteException ex)
            {
                throw ex;
            }
        }

        public async Task<UserPosts> GetByUserId(Guid userId)
        {
            var filter = Builders<UserPostsEntity>.Filter.Eq(u => u.UserId, userId);

            var result = await _queryExecutor.FindAsync(filter);

            return result?.AsEnumerable()?.FirstOrDefault()?.ToUserPosts() ?? null;
        }

        public async Task<UserPosts> GetById(Guid id)
        {
            var result = await _queryExecutor.FindByIdAsync<UserPostsEntity>(id);

            return result?.ToUserPosts() ?? null;
        }

        public async Task AddLikeToUserPostAsync(Guid userId, Guid postId)
        {
            var filter = Builders<UserPostsEntity>.Filter.ElemMatch(u => u.Posts, Builders<PostEntity>.Filter.Eq(u => u.Id, postId));

            var update = Builders<UserPostsEntity>.Update.AddToSet(u => u.Posts[-1].Likes, userId);


            await _queryExecutor.UpdateAsync(filter, update);
        }
        public async Task RemoveLikeFromUserPostAsync(Guid userId, Guid postId)
        {
            var filter = Builders<UserPostsEntity>.Filter.ElemMatch(u => u.Posts, Builders<PostEntity>.Filter.Eq(u => u.Id, postId));

            var update = Builders<UserPostsEntity>.Update.Pull(u => u.Posts[-1].Likes, userId);


            await _queryExecutor.UpdateAsync(filter, update);
        }

        public async Task AddDislikeToUserPostAsync(Guid userId, Guid postId)
        {
            var filter = Builders<UserPostsEntity>.Filter.ElemMatch(u => u.Posts, Builders<PostEntity>.Filter.Eq(u => u.Id, postId));

            var update = Builders<UserPostsEntity>.Update.AddToSet(u => u.Posts[-1].Dislikes, userId);


            await _queryExecutor.UpdateAsync(filter, update);
        }
        public async Task RemoveDislikeFromUserPostAsync(Guid userId, Guid postId)
        {
            var filter = Builders<UserPostsEntity>.Filter.ElemMatch(u => u.Posts, Builders<PostEntity>.Filter.Eq(u => u.Id, postId));

            var update = Builders<UserPostsEntity>.Update.Pull(u => u.Posts[-1].Dislikes, userId);


            await _queryExecutor.UpdateAsync(filter, update);
        }
        public async Task AddCommentToUserPostAsync(Comment comment, Guid postId)
        {
            var filter = Builders<UserPostsEntity>.Filter.ElemMatch(u => u.Posts, Builders<PostEntity>.Filter.Eq(u => u.Id, postId));

            var update = Builders<UserPostsEntity>.Update.AddToSet(u => u.Posts[-1].Comments, comment);


            await _queryExecutor.UpdateAsync(filter, update);
        }


        public async Task UpdateAsync(Guid id, Post[] posts)
        {
            var filter = Builders<UserPostsEntity>.Filter.Eq(u => u.Id, id);

            var update = Builders<UserPostsEntity>.Update.Set(s => s.Posts, posts.Select(s => PostEntity.ToPostEntity(s)));

            await _queryExecutor.UpdateAsync(filter, update);
          
        }

        public async Task SaveImage(Guid id,string image)
        {
            var filter = Builders<UserPostsEntity>.Filter.ElemMatch(u => u.Posts, Builders<PostEntity>.Filter.Eq(u => u.Id, id));

            var update = Builders<UserPostsEntity>.Update
                .Set(u => u.Posts[-1].Image, image);
            await _queryExecutor.UpdateAsync(filter, update);

        }
    }
}
