using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarColourDal : ICarColourDal
    {
        public void Add(CarColour entity)
        { 
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(CarColour entity)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public CarColour Get(Expression<Func<CarColour, bool>> filter)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                return context.Set<CarColour>().SingleOrDefault(filter);

            }
        }

        public List<CarColour> GetAll(Expression<Func<CarColour, bool>> filter = null)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                return filter == null ? context.Set<CarColour>().ToList() : context.Set<CarColour>().Where(filter).ToList();

            }
        }

        public void Update(CarColour entity)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                var updatedEntity = context.Entry(entity);
               updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
