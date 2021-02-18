﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DtOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarsDatabaseContext>, IRentalDal
    {
        public List<RentDetailDTOs> RentDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.CarBrands
                             on r.Id equals b.Id
                             join cstr in context.Customers
                             on r.CustomerId equals cstr.CustomerId
                             join us in context.Users
                             on cstr.UserId equals us.UserId
                             select new RentDetailDTOs
                             {
                                 Id=r.Id,
                                CarId=c.Id,
                                CarName=b.BrandName,
                               UserName=us.FirstName+" "+us.LastName,
                               RentDate=r.RentDate,
                                ReturnDate=r.ReturnDate
                               };
                return result.ToList();
            }
        }
    }
}
//using (CarsDatabaseContext context = new CarsDatabaseContext())
//{
//    var result = from c in context.Cars
//                 join cb in context.CarBrands
//                 on c.ColourId equals cb.Id
//                 join cc in context.CarColours
//                 on c.ColourId equals cc.Id

//                 select new CarDetailDTO
//                 {
//                     Id = c.Id,
//                     CarName = cb.BrandName,
//                     ColourName = cc.ColourName,
//                     DailyPrice = c.DailyPrice,
//                     Description = c.Description
//                 };
//    return result.ToList();
//}