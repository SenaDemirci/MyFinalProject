using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of C#
            using (TContext context = new TContext()) //işi bitince bellekten silinmesi için yaptık
            {
                var addedEntity = context.Entry(entity); //veritabanından gönderdiğim nesneyle eşleştir (karşılaştır)
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) //işi bitince bellekten silinmesi için yaptık
            {
                var deletedEntity = context.Entry(entity); //veritabanından gönderdiğim nesneyle eşleştir (karşılaştır)
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) //işi bitince bellekten silinmesi için yaptık
            {
                var updatedEntity = context.Entry(entity); //veritabanından gönderdiğim nesneyle eşleştir (karşılaştır)
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
