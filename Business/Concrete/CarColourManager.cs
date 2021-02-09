using Business.Abstract;
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

        public void Add(CarColour carColour)
        {
            _carColourDal.Add(carColour);
        }

        public void Delete(CarColour carColour)
        {
            _carColourDal.Delete(carColour);
        }

        public List<CarColour> GetAll()
        {
            return _carColourDal.GetAll();
        }

        public List<CarColour> GetById(int id)
        {
            return _carColourDal.GetAll(p => p.Id == id);
           }

        public void Update(CarColour carColour)
        {
            _carColourDal.Delete(carColour);
        }
    }
}
