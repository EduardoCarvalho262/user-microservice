using User.API.Domain.Models;
using User.API.Service.Interfaces;

namespace User.API.Service.Services;

public class UserService : IUserService
{
    private readonly List<UserModel> _users = new List<UserModel>() { new UserModel { Id =  Guid.Parse("ba094234-0271-4df0-b350-dcab08891149"), Name = "Eduardo"}};

    public List<UserModel> GetAll()
    {
        return _users;
    }

    public UserModel GetById(Guid id)
    {
        var result = _users.Find(x => x.Id == id);
        if (result != null) return result;

        return null;
    }

    public UserModel CreateUser(UserModel user)
    {
        _users.Add(user);
        return user;
    }
}