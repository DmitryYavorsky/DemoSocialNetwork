using System.Threading.Tasks;

namespace DSN.Common.Mongo
{
    public interface IMongoDbSeeder
    {
        Task SeedAsync();
    }
}
