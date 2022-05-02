using Dislinkt.Posts.Core.Repositories;
using Dislinkt.Posts.Domain.Posts;
using Dislinkt.Posts.Persistance.MongoDB.Common;
using Dislinkt.Posts.Persistance.MongoDB.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;

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
    }
}
