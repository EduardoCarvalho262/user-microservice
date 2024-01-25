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
        }
    }
}
