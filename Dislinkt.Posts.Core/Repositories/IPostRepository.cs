using Dislinkt.Posts.Domain.Posts;
using System.Threading.Tasks;

namespace Dislinkt.Posts.Core.Repositories
{
    public interface IPostRepository
    {
        Task AddAsync(Post post);
    }
}
