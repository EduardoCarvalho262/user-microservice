using Moq;
using User.API.Controllers.HealthCheck;
using User.API.Controllers.UserApiController;
using User.API.Interfaces;
using User.API.Models;
using User.API.Services;

namespace User.UnitTests
{
    public class UserUnitTests
    {
        private static readonly Guid GuidTest = Guid.Parse("ba094234-0271-4df0-b350-dcab08891149");
        private static readonly Mock<IUserService> _UserServiceMock = new Mock<IUserService>();
        
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
        public void GivenAUserModelWhenCreateAUserReturnUserModelIdAndName()
        {
            //Arrange
            var newUser = new UserModel();

            //Act
            newUser.Id = GuidTest;
            newUser.Name = "Eduardo";


            //Assert
            Assert.Equal("Eduardo", newUser.Name);
            Assert.Equal(GuidTest, newUser.Id);
        }

        [Fact]
        public void GivenAControllerMethodGetAllWhenCallThenReturnAllUsers()
        {
            //Arrange
            _UserServiceMock.Setup(p => p.GetAll()).Returns(new List<UserModel>() {new UserModel { Id = GuidTest, Name = "Teste"}});
            var userController = new UserController(_UserServiceMock.Object);

            //Act
            var result = userController.GetAllUsers();

            //Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public void GivenAObjectUserServiceWhenImplementReturnAllCustomers()
        {
            var userService = new UserService();

            var result = userService.GetAll();
            
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public void GivenAUserServiceWhenPassAIDReturnOneUser()
        {
            //Arrange
            var userService = new UserService();
            var nameExpected = "Eduardo";

            //Act
            var result = userService.GetById(GuidTest);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(nameExpected, result.Name);
        }
        
        [Fact]
        public void GivenAUserServiceWhenPassAidWrongReturnNull()
        {
            //Arrange
            var userService = new UserService();

            //Act
            var result = userService.GetById(Guid.NewGuid());

            //Assert
            Assert.NotNull(result);
            Assert.Null(result.Name);
        }

        [Fact]
        public void GivenAControllerMethodGetByIdWhenCallReturnAUser()
        {
            //Arrange
            var userExpected = new UserModel() {Id = GuidTest, Name = "Edu"};
            _UserServiceMock.Setup(p => p.GetById(It.IsAny<Guid>())).Returns(userExpected);
            var userController = new UserController(_UserServiceMock.Object);
            
            //Act
            var result = userController.GetById(GuidTest);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(userExpected.Name, result.Name);
        }
    }
}