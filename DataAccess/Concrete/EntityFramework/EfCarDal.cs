using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DtOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsDatabaseContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                var result = from c in context.Cars
                             join cb in context.CarBrands
                             on c.ColourId equals cb.Id
                             join cc in context.CarColours
                             on c.ColourId equals cc.Id

                             select new CarDetailDTO
                             {
                                 Id = c.Id,
                                 CarName = cb.BrandName,
                                 ColourName = cc.ColourName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
            
        }
    }
}
