using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


  
   
       public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), CarImageMessages.CarImageListed);
          
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci => ci.CarId == carId));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == id));
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimitExpired(carImage.CarId),
                CheckIfImageExtensionValid(file)
                ) ;
            if (result!=null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date_ = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageExists(carImage.Id));
            if (result != null)
            {
                return result;
            }
            string path = GetById(carImage.Id).Data.ImagePath;
            FileHelper.Delete(path);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimitExpired(carImage.CarId),
                CheckIfImageExtensionValid(file),
                CheckIfImageExists(carImage.Id)
                );
            if (result != null)
            {
                return result;
            }
            CarImage oldData = GetById(carImage.Id).Data;
           carImage.ImagePath = FileHelper.Update(file, oldData.ImagePath);
            carImage.Date_ = DateTime.Now;
            carImage.CarId = oldData.CarId;
            _carImageDal.Update(carImage);
            return new SuccessResult();

        }
        private IResult CheckIfImageLimitExpired(int carId)
        {
            var result = _carImageDal.GetAll(cI => cI.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(CarImageMessages.ImageLimitExpiredForCar);
            }
            return new SuccessResult();
        }
        private IResult  CheckIfImageExtensionValid(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);
            if (extension==".jpg"|| extension == ".png" || extension == ".jpeg" || extension == ".gif" )
            {
                return new SuccessResult();
            }
            return new ErrorResult(CarImageMessages.ValidImageFileTypes);

        }
        private List<CarImage> CheckIfCarHaveNoImage(int carId)
        {
            string path = Directory.GetCurrentDirectory() + @"\wwwroot\images\default.png";
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (!result.Any())
            {
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path } };
            }
            return result;
         }
        private IResult CheckIfImageExists(int id)
        {
            var result = _carImageDal.Get(ci => ci.Id == id);
            if (result !=null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
  }



