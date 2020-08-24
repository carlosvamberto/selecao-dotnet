using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IndraApp.ApplicationCore.Interfaces.Services
{
    public interface IService<TEntity>
    {
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
        void Delete(TEntity entity);
    }
}
