using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DtOs
{
   public  class CarDetailDTO:IDTo
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string  CarName { get; set; }
        public string ColourName { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get; set; }
  
    }
}
