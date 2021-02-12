using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarBrandService
    {
       IDataResult< List<CarBrand> >GetAll();
      IDataResult<  List<CarBrand>> GetById(int id);
        IResult Add(CarBrand carBrand);
        IResult Delete(CarBrand carBrand);
        IResult Update(CarBrand carBrand);
       

    }
}
