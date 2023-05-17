using KidstellarCase.Domain.Enums;

namespace KidstellarCase.Web.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
