using ChatApp.DataAccess.Contracts;
using ChatApp.Domains;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ChatApp.DataAccess.Data.Repositories
{
    internal class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly ChatAppDbContext _dbContext;
        public BaseRepository(ChatAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Create(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            entity.CreateDate = DateTime.UtcNow;
            _dbContext.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual IQueryable<TEntity> GetAllByCondition(Expression<Func<TEntity, bool>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException();
            return _dbContext.Set<TEntity>().Where(expression);
        }

        public virtual TEntity GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException();
            return _dbContext.Set<TEntity>().FirstOrDefault(expression);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            entity.CreateDate = DateTime.UtcNow;
            _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
