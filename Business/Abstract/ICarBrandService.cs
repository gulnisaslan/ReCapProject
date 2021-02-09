using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarBrandService
    {
        List<CarBrand> GetAll();
        void Add(CarBrand carBrand);
        void Delete(CarBrand carBrand);
        void Update(CarBrand carBrand);
        List<CarBrand> GetById(int id);

    }
}
