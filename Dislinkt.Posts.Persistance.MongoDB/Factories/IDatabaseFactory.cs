using MongoDB.Driver;

namespace Dislinkt.Posts.Persistance.MongoDB.Factories
{
    public interface IDatabaseFactory
    {
        IMongoDatabase Create();
    }
}
