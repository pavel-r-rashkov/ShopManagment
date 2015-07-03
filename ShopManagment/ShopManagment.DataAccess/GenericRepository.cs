﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShopManagment.Data;
using ShopManagment.DataAccess.Interfaces;

namespace ShopManagment.DataAccess
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected DbContext context;
        protected DbSet<TEntity> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            string properties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? page = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> query = this.dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (properties != null)
            {
                var propertiesToInclude = properties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var property in propertiesToInclude)
                {
                    query = query.Include(property);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            //if (page != null && pageSize != null)
            //{
            //    return query.ToPagedList((int)page, (int)pageSize);
            //}

            return query.ToList();
        }

        public TEntity GetById(object id)
        {
            return this.dbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            this.dbSet.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (this.context.Entry(entity).State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }
            this.dbSet.Remove(entity);
        }
    }
}
