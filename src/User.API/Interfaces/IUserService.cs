using User.API.Models;

namespace User.API.Interfaces;

public interface IUserService
{
    public List<UserModel> GetAll();
    public UserModel GetById(Guid id);
    public UserModel CreateUser(UserModel user);
}