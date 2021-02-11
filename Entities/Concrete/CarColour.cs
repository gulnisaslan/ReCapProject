using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public  class CarColour:IEntityRepository
    {
        public int Id { get; set; }
        public string  ColourName { get; set; }
    }
}
