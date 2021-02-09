using Business.Abstract;
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

        public void Add(CarBrand carBrand)
        {
            if (carBrand.BrandName.Length == 0)
            {
                Console.WriteLine("Araba adı en az iki karakter olmak zorundadır. lütfen tekrar ad bilgisi giriniz.");
            }
            else
            {
                      _carBrandDal.Add(carBrand);
                Console.WriteLine("Araba bilgisi eklendi.");
            }
        }

        public void Delete(CarBrand carBrand)
        {
            _carBrandDal.Delete(carBrand);
            Console.WriteLine("Araba bilgisi silme işlemi başarılı");
        }

        public List<CarBrand> GetAll()
        {
            return _carBrandDal.GetAll();
           
        }

        public List<CarBrand> GetById(int id)
        {
            return _carBrandDal.GetAll(c => c.Id == id);
                }

        public void Update(CarBrand carBrand)
        {
            if (carBrand.BrandName.Length == 2)
            {
                _carBrandDal.Update(carBrand);
                Console.WriteLine("Araba bilgisi güncellendi");
            }
            else
            {
                Console.WriteLine("Araba adı en az iki karakter olmak zorundadır. lütfen tekrar ad bilgisi giriniz.");
            }

        }
    }
}
