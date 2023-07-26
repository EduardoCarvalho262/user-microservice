using User.API.Interfaces;
using User.API.Models;

namespace User.API.Services;

public class UserService : IUserService
{
    private List<UserModel> _users = new List<UserModel>() { new UserModel { Id = Guid.NewGuid(), Name = "Scott"}}; 
    public List<UserModel> GetAll()
    {
        return _users;
    }
}