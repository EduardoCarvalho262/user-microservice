using User.API.Models;

namespace User.API.Interfaces;

public interface IUserService
{
    public List<UserModel> GetAll();
}