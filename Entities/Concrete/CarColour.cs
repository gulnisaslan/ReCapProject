using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public  class CarColour:IEntity
    {
        public int Id { get; set; }
        public string  ColourName { get; set; }
    }
}
