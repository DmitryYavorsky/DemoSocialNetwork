using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DSN.Common.Types;

namespace DSN.Common.Mongo
{
    public interface IMongoRepository<TEntity> where TEntity: IIdentifiable
    {
        Task<TEntity> GetAsync(Guid id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
    }
}
