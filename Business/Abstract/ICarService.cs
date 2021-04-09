using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DtOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public  interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetDailyPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetId(int id);

        IDataResult<List<Car>> GetBrandId(int brandId);
        IDataResult<List<Car>> GetColourId(int colourId);


        IDataResult< List<CarDetailDTO>> GetCarDetails();

    }
}
