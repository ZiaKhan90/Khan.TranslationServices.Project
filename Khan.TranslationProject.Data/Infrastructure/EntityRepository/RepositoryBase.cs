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
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly IUnitOfWork unitOfWork;
        protected readonly IDbSet<T> dbSet;

        protected RepositoryBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.dbSet = DataContext.Set<T>();
        }

        protected IDbContext DataContext
        {
            get { return unitOfWork.Context; }
        }

        public T SingleOrDefault(Expression<Func<T, bool>> whereCondition)
        {
            var dbResult = dbSet.Where(whereCondition).FirstOrDefault();
            return dbResult;
        }
        
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> whereCondition)
        {
            return dbSet.Where(whereCondition).AsEnumerable();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }
        
        public bool Exists(Expression<Func<T, bool>> whereCondition)
        {
            return dbSet.Any(whereCondition);
        }

        public int Count(Expression<Func<T, bool>> whereCondition)
        {
            return dbSet.Where(whereCondition).Count();
        }

        public IEnumerable<T> GetPagedRecords(Expression<Func<T, bool>> whereCondition, Expression<Func<T, string>> orderBy, int pageNo, int pageSize)
        {
            return (dbSet.Where(whereCondition).OrderBy(orderBy).Skip((pageNo - 1) * pageSize).Take(pageSize)).AsEnumerable();
        }

        public IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters)
        {
            return ((DbContext)unitOfWork.Context).Database.SqlQuery<T>(query, parameters);
        }

        public virtual void UpdateRange(IList<T> entities)
        {
            foreach (var entity in entities)
            {
                dbSet.Attach(entity);
                ((DbContext)unitOfWork.Context).Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            
        }

        public virtual void SetModified(object entity)
        { 
            if(entity != null)
                ((DbContext)unitOfWork.Context).Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void SetModified(object entity, params string[] properties)
        {
            var entry = ((DbContext)unitOfWork.Context).Entry(entity);
            entry.State = System.Data.Entity.EntityState.Unchanged;
            foreach (var property in properties)
            {
                entry.Property(property).IsModified = true;
            }
            ((DbContext)unitOfWork.Context).Configuration.ValidateOnSaveEnabled = false;

        }

        public void SetModified(T entity)
        {
            if (entity != null)
                ((DbContext)unitOfWork.Context).Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void SetUnChanged(object entity)
        { 
            if(entity != null)
                ((DbContext)unitOfWork.Context).Entry(entity).State = System.Data.Entity.EntityState.Unchanged;
        }

        public virtual void SetDetached(object entity)
        { 
            if(entity != null)
                ((DbContext)unitOfWork.Context).Entry(entity).State = System.Data.Entity.EntityState.Detached;
        }

        public void DeleteRange(Expression<Func<T, bool>> whereCondition)
        {
            IEnumerable<T> entities = this.GetAll(whereCondition);
            foreach (T entity in entities)
            {
                if (((DbContext)unitOfWork.Context).Entry(entity).State == System.Data.Entity.EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
            }
        }

        public virtual void SetAdded(object entity)
        { 
            if(entity != null)
                ((DbContext)unitOfWork.Context).Entry(entity).State = System.Data.Entity.EntityState.Added;
        }

        public T SetAdded(T entity)
        {
            if (entity != null)
                ((DbContext)unitOfWork.Context).Entry(entity).State = System.Data.Entity.EntityState.Added;

            return entity;
        }

        public virtual void SetDeleted(object entity)
        { 
            if(entity != null)
                ((DbContext)unitOfWork.Context).Entry(entity).State = System.Data.Entity.EntityState.Deleted;
        }

        public T SetDeleted(T entity)
        {
            if (entity != null)
                ((DbContext)unitOfWork.Context).Entry(entity).State = System.Data.Entity.EntityState.Deleted;

            return entity;
        }


        public virtual int ExecuteSql(string query, params object[] parameters)
        {
            return ((DbContext)unitOfWork.Context).Database.ExecuteSqlCommand(query, parameters);
        }

        public virtual IEnumerable<T> SqlQuery<T>(string query, params object[] parameters)
        {
            return ((DbContext)unitOfWork.Context).Database.SqlQuery<T>(query, parameters);
        }
    }
}
