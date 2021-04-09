using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DtOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(CarMessages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(CarMessages.CarDidNotAdd);


        }

        public IDataResult<List<Car>> GetAll()
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), CarMessages.CarListed);
        }

        public IDataResult<List<Car>> GetBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(bi => bi.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails(), CarMessages.CarListed);
        }

 
        public IDataResult<List<Car>> GetColourId(int colourId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(co => co.ColourId == colourId));
        }

        public IDataResult<List<Car>> GetDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(dp=>dp.DailyPrice>min&&dp.DailyPrice<max), CarMessages.CarListed);

        }

        public IDataResult<List<Car>> GetId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.Id==id), CarMessages.CarListed);
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(CarMessages.CarUpdated);
        }
    }

    
}



