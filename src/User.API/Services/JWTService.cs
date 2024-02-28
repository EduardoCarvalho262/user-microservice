using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User.API.Interfaces;
using User.API.Models;

namespace User.API.Services
{
    public class JWTService : IJWTService
    {
        public string CreateToken(UserModel user)
        {
            if (user.Name == null)
            {
                return "User Invalid";
            }
                
            // Criar credencias token - Header
            var credenciais = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minhachaveincrivelparatestetralalalalala")), SecurityAlgorithms.HmacSha256);

            // Criar claims - Payload
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(ClaimTypes.Role, "Admin")
            };

            //Configurando token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "AuthServer",
                Audience = "AngularClient",
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credenciais
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            try
            {
                //Configurando validação token
                var parametrosValidacao = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "AuthServer",
                    ValidAudience = "AngularClient",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minhachaveincrivelparatestetralalalalala"))
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(token, parametrosValidacao, out SecurityToken securityToken);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao validar o token: {ex.Message}");
                return false;
            }
        }
    }
}