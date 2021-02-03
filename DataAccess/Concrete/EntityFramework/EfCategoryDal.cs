using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : ICategoryDal
    {
        public void Add(Category entity)
        {

        }

        public void Delete(Category entity)
        {
            
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            
        }

        public void Update(Category entity)
        {
            
        }
    }
}
