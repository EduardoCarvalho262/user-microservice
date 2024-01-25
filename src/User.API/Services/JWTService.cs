using User.API.Interfaces;
using User.API.Models;

namespace User.API.Services
{
    public class JWTService : IJWTService
    {
        public string CreateToken(UserModel user)
        {
            return "Implementar";
        }

        public string GetToken()
        {
            throw new NotImplementedException();
        }

        public bool ValidateToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
