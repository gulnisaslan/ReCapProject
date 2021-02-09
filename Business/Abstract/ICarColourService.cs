using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarColourService
    {
        List<CarColour> GetAll();
        void Add(CarColour carColour);
        void Delete(CarColour carColourr);
        void Update(CarColour carColour);
        List<CarColour> GetById(int id);
    } 
}
