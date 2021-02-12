using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarBrandManager : ICarBrandService
       
    {
        ICarBrandDal _carBrandDal;

        public CarBrandManager(ICarBrandDal carBrandDal)
        {
            _carBrandDal = carBrandDal;
        }

        public IResult Add(CarBrand carBrand)
        {
            if (carBrand.BrandName.Length == 0)
            {
                return new ErrorResult(CarBrandMessages.CarBrandDidNotAdd);
            }
            else
            {
                      _carBrandDal.Add(carBrand);
                return new SuccessResult(CarBrandMessages.CarBrandAdded);
            }
        }

        public IResult Delete(CarBrand carBrand)
        {
        _carBrandDal.Delete(carBrand);
         return new SuccessResult(CarBrandMessages.CarBrandDeleted);
         }

        public IDataResult<List<CarBrand>> GetAll()
        {
            return new SuccessDataResult<List<CarBrand>>(_carBrandDal.GetAll(),CarBrandMessages.CarBrandListed);
           
        }

        public IDataResult< List<CarBrand>> GetById(int id)
        {
            return new SuccessDataResult<List<CarBrand>> (_carBrandDal.GetAll(c => c.Id == id),CarBrandMessages.CarBrandListed)  ;
              
          }

        public IResult Update(CarBrand carBrand)
        {
            if (carBrand.BrandName.Length == 2)
            {
                _carBrandDal.Update(carBrand);
                return new SuccessResult(CarBrandMessages.CarBrandUpdated);
            }
            else
            {
                return new ErrorResult(CarBrandMessages.CarBrandDidNotUpdate);

            }

        }
    }
}
