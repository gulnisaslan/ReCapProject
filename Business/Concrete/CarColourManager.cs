using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarColourManager : ICarColourService
    {
        ICarColourDal _carColourDal;

        public CarColourManager(ICarColourDal carColourDal)
        {
            _carColourDal = carColourDal;
        }
       [SecuredOperation("colouradd,admin")]
        [ValidationAspect(typeof(CarColourValidator))]
        [CahceAspect(10)]
        public IResult Add(CarColour carColour)
        {
      
                return new SuccessResult(CarColourMessages.CarColourDidNotAdd);
          
        
        }

        public IResult Delete(CarColour carColour)
        {
            _carColourDal.Delete(carColour);
            return new SuccessResult(CarColourMessages.CarColourDeleted);
        }

        public IDataResult<List<CarColour>>GetAll()
        {
            return new SuccessDataResult<List<CarColour>>(_carColourDal.GetAll(),CarColourMessages.CarColourListed);
        }

        public IDataResult<List<CarColour>> GetById(int id)
        {
            return new SuccessDataResult<List<CarColour>>(_carColourDal.GetAll(c=>c.Id==id),CarColourMessages.CarColourListed);

        }
        [ValidationAspect(typeof(CarColourValidator))]
        public IResult Update(CarColour carColour)
        {
            _carColourDal.Update(carColour);
            return new SuccessResult(CarColourMessages.CarColourUpdated);
        }
    }
}
