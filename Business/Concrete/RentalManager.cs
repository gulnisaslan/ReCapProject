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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(RentalMessages.RentalAdded);
        }

     

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(RentalMessages.RentalAdded);
        }

        public IDataResult<List<Rental>> GetAll()
        {

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), RentalMessages.RentalListed);

        }

        public IDataResult<List<Rental>> GetById(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.Id == id), RentalMessages.RentalListed);
        }

        public IDataResult<List<RentDetailDTOs>> GetRentDetailDTO()
        {
            return new SuccessDataResult<List<RentDetailDTOs>>(_rentalDal.RentDetails());
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {

            _rentalDal.Update(rental);
            return new SuccessResult(RentalMessages.RentalUpdated);



        }
      
    }
}
