using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Entity;
using Khan.TranslationProject.Data.Infrastructure;
using Khan.TranslationProject.Data.Context;
using System.Linq.Expressions;

namespace Khan.TranslationProject.Data.Infrastructure.EntityRepository
{
    public interface IRepositoryBase<T> 
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> whereCondition);
        T SetAdded(T entity);
        T SetDeleted(T entity);
        void SetModified(T entity);
        void UpdateRange(IList<T> entities);
        void SetModified(object entity, params string[] properties);
        void DeleteRange(Expression<Func<T, bool>> whereCondition);
        bool Exists(Expression<Func<T, bool>> whereCondition);
    }
}
