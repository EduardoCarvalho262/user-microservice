using System.Text.RegularExpressions;
using User.API.Models;
using User.API.Services;

namespace User.UnitTests
{ 
    public class JWTUnitTests
    {
        JWTService jwtService = new JWTService();

        [Fact]
        public void GiveACreateUser_WhenPassUsernameAndPassword_ReturnToken()
        {
            //Arrange
            var user = new UserModel { Id = Guid.NewGuid(), Name = "Eduardo"};

            //Act
            var response = jwtService.CreateToken(user);

            //Assert
            Assert.NotNull(response);
            Assert.True(IsValidJwtToken(response));
        }

        [Fact]
        public void GiveACreateUser_WhenPassNullUsernameAndPassword_ReturnUserInvalid()
        {
            //Arrange
            var user = new UserModel { Id = Guid.NewGuid(), Name = null };

            //Act
            var response = jwtService.CreateToken(user);

            //Assert
            Assert.NotNull(response);
            Assert.Equal("User Invalid", response);
        }


        [Fact]
        public void GiveAToken_WhenPassToMethodValidToken_ReturnTrue()
        {
            //Arrange
            var user = new UserModel { Id = Guid.NewGuid(), Name = "Eduardo" };

            //Act
            var token = jwtService.CreateToken(user);
            var response = jwtService.ValidateToken(token);

            //Assert
            Assert.NotNull(response);
            Assert.True(response);
        }

        private bool IsValidJwtToken(string token)
        {
            string jwtRegexPattern = @"^[A-Za-z0-9-_]+\.[A-Za-z0-9-_]+\.[A-Za-z0-9-_=]+$";

            return Regex.IsMatch(token, jwtRegexPattern);
        }
    }
}
