using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    class CarImageManager : ICarImageService

    {
        EfCarImageDal _carImageDal;
        

        public CarImageManager(EfCarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
          
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage,IFormFile file)
        {
           var result= BusinessRules.Run(CheckIfImageCountOfCarCorrect(carImage.CarId));
            if (result!=null)
            {
                return result;

                   
            }
            carImage.ImagePath = FileHelper.Add(file);
            _carImageDal.Add(carImage);
            return new SuccessResult(CarImageMessages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var oldPath = $@"{Environment.CurrentDirectory}\\wwwroot{_carImageDal.Get(p => p.Id == carImage.Id).ImagePath}";
            FileHelper.Delete(oldPath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(CarImageMessages.CarImageDontAdd);
        }

        //public IDataResult<List<CarImage>> Get(int Id)
        //{
        //    return new SuccessDataResult<List<CarImage>>(_carImageDal.Get(ci => ci.Id == Id));
        //}

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetById(int Id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci=>ci.Id ==Id));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci => ci.CarId == carId));
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage,IFormFile file)
        {
            var oldPath = $@"{Environment.CurrentDirectory}\\wwwroot{_carImageDal.Get(p => p.Id == carImage.Id).ImagePath}";
            carImage.ImagePath = FileHelper.Update(oldPath, file);
            _carImageDal.Update(carImage);
            return new SuccessResult(CarImageMessages.CarImageUpdate);
        }

        private IResult CheckIfImageCountOfCarCorrect(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count;
            if (result >= 5)
            {
                return new SuccessResult(CarImageMessages.ImageCountSuccess);
            }
            return new ErrorResult(CarImageMessages.ImageCountError);
        }

    

    }
}


