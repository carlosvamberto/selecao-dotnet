using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IndraApp.ApplicationCore.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);        
        void Delete(TEntity entity);
    }
}
