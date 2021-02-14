using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DtOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public  interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<Rental>> GetById(int id);
        IDataResult<List<RentDetailDTOs>> GetRentDetailDTO();

        IDataResult<List<Rental>> GetAll();



    }
}
