using User.API.Domain.Models;

namespace User.API.Service.Interfaces;

public interface IUserService
{
    public List<UserModel> GetAll();
    public UserModel GetById(Guid id);
    public UserModel CreateUser(UserModel user);
}