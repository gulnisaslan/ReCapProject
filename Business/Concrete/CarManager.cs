using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IEnumerable<Car> GetDailyPrice(double v)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
            Console.WriteLine("Araba  ekleme işlemi başarıyla gerçekleşti");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araba  silme  işlemi başarıyla gerçekleşti ");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
            Console.WriteLine("Araba  listeleme  işlemi başarıyla gerçekleşti");
        }

        public List<Car> GetId(int id)
        {
            return _carDal.GetAll(c => c.Id == id);
        }

        public List<Car> GetDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c=>c.DailyPrice>min && c.DailyPrice<max);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
