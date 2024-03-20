

using User.API.Domain.Models;
using User.API.Service.Interfaces;
using User.API.Service.Services;

namespace User.UnitTests
{
    public class UserServiceUnitTest
    {
        private readonly IUserService _userService;

        public UserServiceUnitTest()
        {
            // Aqui você pode inicializar uma instância de UserService ou usar uma biblioteca de mocking como Moq
            _userService = new UserService();
        }

        [Fact]
        public void GetAll_ReturnsAllUsers()
        {
            // Arrange
            var expectedUsers = new List<UserModel>
            {
                new UserModel { Id = Guid.Parse("ba094234-0271-4df0-b350-dcab08891149"), Name = "Eduardo" }
            };

            // Act
            var actualUsers = _userService.GetAll();

            // Assert
            Assert.Equal(expectedUsers.Count, actualUsers.Count);
            Assert.Equal(expectedUsers[0].Id, actualUsers[0].Id);
            Assert.Equal(expectedUsers[0].Name, actualUsers[0].Name);
        }

        [Fact]
        public void GetById_ReturnsUserById()
        {
            // Arrange
            var userId = Guid.Parse("ba094234-0271-4df0-b350-dcab08891149");
            var expectedUser = new UserModel { Id = userId, Name = "Eduardo" };

            // Act
            var actualUser = _userService.GetById(userId);

            // Assert
            Assert.Equal(expectedUser.Id, actualUser.Id);
            Assert.Equal(expectedUser.Name, actualUser.Name);
        }

        [Fact]
        public void GetById_ReturnsNullForNonexistentUser()
        {
            // Arrange
            var userId = Guid.NewGuid(); // Gerar um ID que não existe na lista de usuários

            // Act
            var actualUser = _userService.GetById(userId);

            // Assert
            Assert.Null(actualUser);
        }

        [Fact]
        public void CreateUser_AddsUserToList()
        {
            // Arrange
            var newUser = new UserModel { Id = Guid.NewGuid(), Name = "Test User" };

            // Act
            var createdUser = _userService.CreateUser(newUser);
            var retrievedUser = _userService.GetById(newUser.Id);

            // Assert
            Assert.Equal(newUser.Id, createdUser.Id);
            Assert.Equal(newUser.Name, createdUser.Name);
            Assert.Equal(newUser.Id, retrievedUser.Id);
            Assert.Equal(newUser.Name, retrievedUser.Name);
        }
    }
}
