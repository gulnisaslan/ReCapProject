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
    public class EfCarBrandDal : ICarBrandDal
    {
        public void Add(CarBrand entity)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(CarBrand entity)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public CarBrand Get(Expression<Func<CarBrand, bool>> filter)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                return context.Set<CarBrand>().SingleOrDefault(filter);
            }
        }

        public List<CarBrand> GetAll(Expression<Func<CarBrand, bool>> filter = null)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                return filter == null ? context.Set<CarBrand>().ToList() : context.Set<CarBrand>().Where(filter).ToList();
            }
        }

        public void Update(CarBrand entity)
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
