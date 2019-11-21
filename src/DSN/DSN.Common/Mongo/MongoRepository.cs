using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DSN.Common.Types;
using MongoDB.Driver;

namespace DSN.Common.Mongo
{
    public class MongoRepository<TEntity>: IMongoRepository<TEntity> where TEntity : IIdentifiable
    {
        protected IMongoCollection<TEntity> Collection { get; }

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            Collection = database.GetCollection<TEntity>(collectionName);
        }

        public async Task<TEntity> GetAsync(Guid id)
            => await GetAsync(x => x.Id == id);

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
            => await Collection.Find(predicate).SingleOrDefaultAsync();


        public async Task AddAsync(TEntity entity)
            => await Collection.InsertOneAsync(entity);
        
    }
}
