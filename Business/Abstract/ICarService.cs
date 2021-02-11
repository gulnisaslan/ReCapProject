﻿using Entities.Concrete;
using Entities.DtOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public  interface ICarService
    {
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        List<Car> GetAll();
        List<Car> GetDailyPrice(decimal min, decimal max);
        List<Car> GetId(int id);
      
        List<CarDetailDTO> GetCarDetails();

    }
}
