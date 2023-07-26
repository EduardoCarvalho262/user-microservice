using Microsoft.Extensions.Logging;
using User.API.Controllers.HealthCheck;
using Xunit;

namespace User.UnitTests
{
    public class UserUnitTests
    {
        [Fact]
        public void GivenAControllerMethodPingsWhenCallThenReturnPong()
        {

            //Arrange
            var healthCheckController = new HealthCheckController();
            var expected = "Pong";

            //Act
            var result = healthCheckController.Ping();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GivenAControllerMethodGetAllWhenCallThenReturnAllUsers()
        {
            //Arrange
            var userController = new UserController();
            var expected = new List<User>() { Id = Guid.NewGuid(), Name = "Eduardo" };

            //Act
            var result = userController.GetAllUsers();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result);

        }
    }
}