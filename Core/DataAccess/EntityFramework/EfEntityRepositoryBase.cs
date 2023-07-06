using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEnttiy,TContext>:IEntityRepository<TEnttiy>
        where TEnttiy:class, IEntity, new()
        where TContext:DbContext,new()
    {
        public void Add(TEnttiy entity)
        {
            //IDisposible pattern implementation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEnttiy entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEnttiy Get(Expression<Func<TEnttiy, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEnttiy>().SingleOrDefault(filter);
            }
        }

        public List<TEnttiy> GetAll(Expression<Func<TEnttiy, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEnttiy>().ToList() : context.Set<TEnttiy>().Where(filter).ToList();
            }
        }

        public void Update(TEnttiy entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
