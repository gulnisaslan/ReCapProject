using Core.Entities;

namespace Entities.DtOs
{
    public class UserForRegisterDto : IDTo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
