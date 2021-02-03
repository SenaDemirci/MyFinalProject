using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Abstract;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class,new() //generic constraint(generic kısıtlama) class:referans tip
    {                                                         //T, IEntity veya ona bağlı classlar(IEntity yi implemente eden nesneler) olabilir, new lenebilir olmalı, IEntity interface olduğundan new lenemez, bu yüzden IEntity silinir
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter); //ürünlerin belli bir kısmı listelenmek istendiğinde
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
        //List<T> GetAllByCategory(int categoryId);
    }
}
