using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GenericRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Repositories
{
    public abstract class GenericRepository<TC, T> : IGenericRepository<T> where T : class where TC : DbContext, new()
    {
        internal DbSet<T> DbSet;

        public TC Context { get; set; } = new TC();

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = DbSet.Where(predicate);
            return query;
        }

        public virtual T GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<T> Filter(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            //creates an IQueryable object and then applies the filter expression if there is one:
            if (filter != null)
                query = query.Where(filter);

            foreach (
                var includeProperty in includeProperties.Split(new[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            return orderBy?.Invoke(query).ToList() ?? query.ToList();
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = DbSet;
            return query;
        }

        public virtual void Edit(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void DeleteById(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
                DbSet.Attach(entity);
            DbSet.Remove(entity);
        }
    }
}