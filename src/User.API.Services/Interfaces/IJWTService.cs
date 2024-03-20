using User.API.Domain.Models;

namespace User.API.Service.Interfaces
{
    public interface IJWTService
    {
        public string CreateToken(UserModel user);
        public bool ValidateToken(string token);
    }
}
