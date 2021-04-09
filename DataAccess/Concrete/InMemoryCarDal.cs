using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DtOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
           // _cars = new List<Car>
           //{ 
           //     new Car{Id=1,BrandId=1,ColourId=3,DailyPrice=50,Description="Günlük kullanımı için uygundur",ModelYear=2015},
           //     new Car{Id=2,BrandId=2,ColourId=2,DailyPrice=600,Description="Özel günler için uygundur",ModelYear=2020},
           //     new Car{Id=3,BrandId=5,ColourId=1,DailyPrice=400,Description="Nostaljiyi sevenler için",ModelYear=1960},
           //     new Car{Id=4,BrandId=4,ColourId=4,DailyPrice=500,Description="Araba değil karavandır",ModelYear=2019},
           //     new Car{Id=5,BrandId=3,ColourId=5,DailyPrice=100,Description="Günlük kullanımı için uygundur",ModelYear=2018}

           // };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(car);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }

        public List<CarDetailDTO> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            ;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColourId = car.ColourId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description_ = car.Description_;
        }
    }
}
