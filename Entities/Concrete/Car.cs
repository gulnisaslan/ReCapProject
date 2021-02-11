using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Car:IEntityRepository
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColourId { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice{ get; set; }

    }
}
