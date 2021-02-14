using Core.DataAccess;
using Entities.Concrete;
using Entities.DtOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
   public  interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentDetailDTOs> RentDetails(Expression<Func<Rental, bool>> filter = null);
    }
}
