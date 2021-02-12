using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarColourService
    {
 
        IResult Add(CarColour carColour);
        IResult Delete(CarColour carColourr);
        IResult Update(CarColour carColour);
       IDataResult< List<CarColour>> GetById(int id);   
      IDataResult< List<CarColour> >GetAll();
    } 
}
