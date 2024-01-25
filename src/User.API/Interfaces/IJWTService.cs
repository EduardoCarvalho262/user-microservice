using User.API.Models;

namespace User.API.Interfaces
{
    public interface IJWTService
    {
        public string CreateToken(UserModel user);
        public string GetToken();
        public bool ValidateToken(string token);
    }
}
