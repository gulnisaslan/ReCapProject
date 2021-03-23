using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DtOs
{
    public class UserForLoginDto: IDTo
    {
        public string Email { get; set; }
        public string  Password { get; set; }
      
    }
}
