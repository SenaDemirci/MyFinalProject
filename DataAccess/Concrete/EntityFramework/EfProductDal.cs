﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of C#
            using (NorthwindContext context = new NorthwindContext()) //işi bitince bellekten silinmesi için yaptık
            {
                var addedEntity = context.Entry(entity); //veritabanından gönderdiğim nesneyle eşleştir (karşılaştır)
                addedEntity.State = EntityState.Added;
                context.SaveChanges(); 
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) //işi bitince bellekten silinmesi için yaptık
            {
                var deletedEntity = context.Entry(entity); //veritabanından gönderdiğim nesneyle eşleştir (karşılaştır)
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) //işi bitince bellekten silinmesi için yaptık
            {
                var updatedEntity = context.Entry(entity); //veritabanından gönderdiğim nesneyle eşleştir (karşılaştır)
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
