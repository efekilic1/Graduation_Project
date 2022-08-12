using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DAL.EFBase
{

    // Database CRUD işlemlerini yaptığımız Base classımız
    // diğer repositoryler bu base repositorimizden katılım alıyor.



    public class EFBaseRepository <T, TDbContext> :IEFBaseRepository<T>
        where T:class
        where TDbContext: DbContext
    {
        protected readonly TDbContext Context;

        public EFBaseRepository(TDbContext context)
        {
            Context = context;
        }

        public T Add(T entity)
        {
            return Context.Add(entity).Entity;
        }

        public T Update(T entity)
        {
            Context.Update<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.Update(entity);
           
            return entity;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
                return Context.Set<T>().ToList();
            else
            {
                return Context.Set<T>().Where(expression);
            }
        }

        public void Delete(T entity)
        {
            Context.Remove(entity);
            
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().FirstOrDefault(expression);
        }



        public void SaveChanges()
        {
            Context.SaveChanges();
        }


    }
}
